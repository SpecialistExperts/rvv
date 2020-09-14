using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application;
using Application.HesEncryption;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly DataContext _context;
        public OwnersController(DataContext context)
        {
            this._context = context;
        }

        // GET api/owners/5
        [HttpGet("{bsn}")]
        public ActionResult<Owner> Get(string bsn)
        {
            try
            {
                var encryptedBSN = Application.Encryption.Encryption.Encrypt(bsn);
                var owners = _context.Owners
                        .Where(p => p.BSN.Equals(encryptedBSN))
                        .Include(p => p.Registrations)
                        .FirstOrDefault();

                var instance = new Application.Owners.DataAccess(_context);
                var decryptedOwner = instance.GetDecrypedOwner(owners);

                return Ok(decryptedOwner);
            }
            catch
            {
                return Ok("Geen geldig BSN nummer. Probeer een ander BSN nummer");
            }
        }

        // POST api/owners
        [HttpPost]
        public ActionResult<Owner> PostOwner(Owner owner)
        {


            // Check if vacationadress is already registered
            if (_context.Owners.Any(o => o.AdressToRegister == owner.AdressToRegister)) return Ok("Het vakantieadres is al ingeschreven");

            // check if user exists --> add extra registration for new VacationAdress
            string encryptedBSN = Application.Encryption.Encryption.Encrypt(owner.BSN);
            // if (_context.Owners.Any(o => o.BSN == encryptedBSN)){
            //     var personExists = _context.Owners.Where(o => o.BSN == owner.BSN)
            //                                         .Include(o => o.Registrations)  
            //                                         .FirstOrDefault();
            //     var update =  new Application.Owners.DataAccess(_context);  
            //     var newAdress = update.AddAdress(personExists, owner.VacationAdresses);
            //     return Ok(newAdress.Registrations.LastOrDefault().RegistrationNumber); 
            // }

            try
            {
                owner.Registrations = new List<Registration>();
                var instance = new Application.Owners.DataAccess(_context);
                instance.CreateEncrypedOwner(owner);
                return Ok(owner.Registrations.FirstOrDefault().RegistrationNumber);
            }
            catch
            {
                return BadRequest("Not good sir!!");
            }
        }
    }
}
