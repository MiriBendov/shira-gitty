using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using fbi.Models;
using fbi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace fbi.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<String> Login([FromBody] User User)
        {

            var dt = DateTime.Now;

            if (User.Username != "Wray"
            || User.Password != "W2023!")
            {
                return Unauthorized();
            }

            var claims = new List<Claim>
            {
                new Claim("role", "Admin"),
                new Claim("name","john"),
                new Claim("brithdatae","")
            };

            var token = FbiTokenService.GetToken(claims);

            return new OkObjectResult(FbiTokenService.WriteToken(token));
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = "Admin")]
        public IActionResult GenerateBadge(Agent Agent)
        {

            var claims = new List<Claim>
      {
          new Claim("role", "Agent"),
          new Claim("ClearanceLevel", Agent.ClearanceLevel.ToString()),
      };

            var token = FbiTokenService.GetToken(claims);

            return new OkObjectResult(FbiTokenService.WriteToken(token));
        }
    }
}