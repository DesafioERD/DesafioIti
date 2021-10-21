using DesafioIti.Api.Validations;
using DesafioIti.Core.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioIti.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class HashController : Controller
    {
        private readonly IHashService _hashService;

        public HashController(IHashService hashService)
        {
            _hashService = hashService;
        }
        
        [HttpPost]
        public async ValueTask<IActionResult> Post([FromBody] string hashValue)
        {
            var hashValidator = new HashValidator(_hashService);

            var validationResult = await hashValidator.ValidateAsync(hashValue);

            if (!validationResult.IsValid)
            {
                return BadRequest(false);
            }

            return Ok(true);
        }
    }
}
