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
        private byte[] rijndaelKey = new byte[32] { 1, 2, 23, 234, 37, 48, 134, 63, 248, 4, 123, 34, 43, 76, 230, 1, 2, 23, 234, 37, 48, 134, 63, 248, 4, 123, 34, 43, 76, 230, 43, 143 };
        private byte[] rijndaelIV = new byte[16] { 5, 2, 43, 234, 98, 76, 123, 32, 213, 2, 23, 54, 123, 231, 45, 98 };
        private readonly DataContext _context;
        public TestController(DataContext context)
        {
            this._context = context;
        }


        // GET api/test
        [HttpGet]
        public ActionResult<string> Get()
        {

            var encryptedValue = Application.Encryption.Encryption.EncryptStringToBytes("Teststring om te encrypten", rijndaelKey, rijndaelIV);
            var decrypedValue = Application.Encryption.Encryption.DecryptStringFromBytes(encryptedValue, rijndaelKey, rijndaelIV);


            return Ok("De encrypted string --->" + Convert.ToBase64String(encryptedValue) + "   De decrypted string ---> " + decrypedValue);
        }
    }
}
