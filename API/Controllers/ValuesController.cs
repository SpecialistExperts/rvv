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


        // GET api/values
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Owner>>> Get()
        // {
        //     // var instance = new RandomNumber();
        //     // var randomnummer = instance.RandomNumberGenerator();
        //     // var x = new Owner{ Id = 4, Name = "Jamooitest123"};
        //     // _context.Add(x);
        //     // _context.SaveChanges();
        //     return Ok("test");
            
        // }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> Get(int id)
        {
            var value = await _context.Values.FindAsync(id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Owner>> PostOwner(Owner owner)
        {
            owner.created_at = DateTime.Now;
            owner.updated_at = DateTime.Now;

            _context.Values.Add(owner);
            await _context.SaveChangesAsync();

            return Ok(owner);
        }

    }
}
