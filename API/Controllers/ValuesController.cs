using System.Collections.Generic;
using System.Linq;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;


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
        public ActionResult<Owner> PostOwner(Request request)
        {
            // Create owner object
            Owner owner = new Owner
            {
                Adress = request.Adress,
                BSN = request.BSN,
                Email = request.Email,
                Gemeente = request.Gemeente,
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                ValidInfo = request.ValidInfo
            };

            // Check if vacationadress is already registered
            string encryptedAdress = Application.Encryption.Encryption.Encrypt(request.AdressToRegister);
            if (_context.Registrations.Any(o => o.Adress == encryptedAdress)) return Ok("Het vakantieadres is al ingeschreven");

            // check if user exists --> add extra registration for new VacationAdress
            string encryptedBSN = Application.Encryption.Encryption.Encrypt(owner.BSN);
            if (_context.Owners.Any(o => o.BSN == encryptedBSN))
            {
                var personExists = _context.Owners.Where(o => o.BSN == encryptedBSN)
                                                    .Include(o => o.Registrations)
                                                    .FirstOrDefault();
                var update = new Application.Owners.DataAccess(_context);
                update.AddAdress(personExists, request.AdressToRegister);
                return Ok(personExists.Registrations.LastOrDefault().RegistrationNumber);
            }

            try
            {
                owner.Registrations = new List<Registration>();
                var instance = new Application.Owners.DataAccess(_context);
                instance.CreateEncrypedOwner(owner, request.AdressToRegister);
                return Ok(owner.Registrations.FirstOrDefault().RegistrationNumber);
            }
            catch
            {
                return BadRequest("Not good sir!!");
            }
        }
    }
}
