using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly DataContext _context;
        public OwnersController(DataContext context){
            this._context = context;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> Get(int id)
        {
            var value = await _context.Owners.FindAsync(id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Owner>> PostOwner(Owner owner)
        {
            // check if vacationadress is already registered
            if (_context.Owners.Any(o => o.VacationAdress == owner.VacationAdress)) return Ok("Het vakantieadres is al ingeschreven");

            // update created/updated with DateTime
            owner.created_at = DateTime.Now;
            owner.updated_at = DateTime.Now;

            // Create registrationnumber    
            var instance = new RandomNumber();
            var RegistrationNumber = instance.CreateRegistration(owner);

            owner.Registrations = RegistrationNumber;
            
            // Add data to database
            _context.Registrations.Add(RegistrationNumber.FirstOrDefault());
            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();

            return Ok(owner);
        }

    }
}
