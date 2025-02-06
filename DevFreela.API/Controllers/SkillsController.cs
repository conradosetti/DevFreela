using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{

    [ApiController]
    [Route("api/skills")]

    public class SkillsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllSkills()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult PostSkills()
        {
            return Ok();
        }
    }
}