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
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            var owners = _context.Owners
                                    .Where(p => p.Id == id)
                                    .Include(p => p.Registrations)
                                    .FirstOrDefault();

            return Ok(owners);
        }

        // POST api/owners
        [HttpPost]
        public ActionResult<Owner> PostOwner(Owner owner)
        {
            
            
            // Check if vacationadress is already registered
            if (_context.Owners.Any(o => o.VacationAdress == owner.VacationAdress)) return Ok("Het vakantieadres is al ingeschreven");
            
            // check if user exists --> add extra registration for new VacationAdress
            if (_context.Owners.Any(o => o.Name == owner.Name)){
                var personExists = _context.Owners.Where(o => o.Name == owner.Name)
                                                    .Include(o => o.Registrations)  
                                                    .FirstOrDefault();
                var update =  new Application.Owners.DataAccess(_context);  
                var newAdress = update.AddAdress(personExists, owner.VacationAdress);
                return Ok(newAdress.Registrations.LastOrDefault().RegistrationNumber); 
            }


            try {
                owner.Registrations = new List<Registration>();
                var instance = new Application.Owners.DataAccess(_context);
                instance.CreateOwner(owner);
            }
            catch{
                return BadRequest("Not good sir!!");
            }

            return Ok(owner.Registrations.FirstOrDefault().RegistrationNumber);
        }

    }
}
