using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Security.Cryptography;

namespace RandomNumberGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomNumberController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRandomFile()
        {
            // Generate random data
            byte[] randomNumber = new byte[2048];  
            System.Security.Cryptography.RandomNumberGenerator.Fill(randomNumber);
       
            var filePath = Path.GetTempFileName();
            System.IO.File.WriteAllBytes(filePath, randomNumber);

            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

    
            return File(stream, "application/octet-stream", "randomdata.bin");
        }
    }
}
