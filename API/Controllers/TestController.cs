using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly DataContext _context;
        public TestController(DataContext context)
        {
            this._context = context;
        }


        // GET api/test
        [HttpGet]
        public ActionResult<string> Get()
        {

            var encryptedValue = Application.Encryption.Encryption.Encrypt("Teststring om te encrypten");
            var decrypedValue = Application.Encryption.Encryption.Decrypt(encryptedValue);


            return Ok("De encrypted string --->" + encryptedValue + "   De decrypted string ---> " + decrypedValue);
        }
    }
}
