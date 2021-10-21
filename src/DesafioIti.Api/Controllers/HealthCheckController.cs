using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioIti.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class HealthCheckController : Controller
    {
        [HttpGet]
        public async ValueTask<IActionResult> Get()
        {
            return (Ok($"I´m fine! {DateTime.Now}"));
        }
    }
}
