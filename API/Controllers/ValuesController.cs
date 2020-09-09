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
        public OwnersController(DataContext context){
            this._context = context;
        }

        // GET api/owners/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(string id)
        {
            // var instance = new HesEncryption();
            // var registrationnumber = instance.Encrypt(1234567890).Substring(0,10);
            var instance = new FormatNumbers();
            var registrationnumber = instance.FormatNumber("123456789012", "0955");
            return Ok(registrationnumber);
        }



        // POST api/owners
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

            // add Gemeente object to Owner
            var gemeente = _context.Gemeentes.Where(b => b.GemeenteNaam.Equals(owner.Gemeente)).ToList();
            // var RegistrationNumberTest = instance.CreateNumber(gemeente.FirstOrDefault());

            owner.Registrations = RegistrationNumber;
            // Add data to database
            _context.Registrations.Add(RegistrationNumber.FirstOrDefault());
            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();

            return Ok(owner);
        }

    }
}
