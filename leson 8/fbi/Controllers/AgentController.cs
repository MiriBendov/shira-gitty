using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FBI.Controllers
{
    [ApiController]
    [Route("[controller]")]
     
    public class AgentController : ControllerBase
    {
        public AgentController() { }


        [HttpGet]
        [Route("[action]")]
        [Authorize(Policy = "Admin")]
        public ActionResult<String> AccessPublicFiles()
        {
            return new OkObjectResult("Public Files Accessed");
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Policy = "ClearanceLevel2")]
        public ActionResult<String> AccessClassifiedFiles()
        {
           // User.Identities
            return new OkObjectResult("Classified Files Accessed");
        }
    }
}