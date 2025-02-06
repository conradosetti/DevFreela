using DevFreela.API.Models;
using DevFreela.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly FreeLanceTotalCostConfig _config;
        private readonly IConfigService _configService;
        
        public ProjectsController(IOptions<FreeLanceTotalCostConfig> options, IConfigService configService)
        {
            _config = options.Value;
            _configService = configService;
        }
        
        //GET api/projects?search=crm
        [HttpGet]
        public IActionResult GetAllProjects(string search = "")
        {
            return Ok(_configService.GetValue());
        }
        //GET api/projects/123
        [HttpGet("{id}")]
        public IActionResult GetProjectById(int id)
        {
            throw new Exception();
            return Ok();
        }
        // POST api/projects
        [HttpPost]
        public IActionResult PostProject(CreateProjectInputModel model)
        {
            if(model.Cost < _config.Minimum || model.Cost > _config.Maximum)
                return BadRequest("Cost is out of bounds");
            return CreatedAtAction(nameof(GetProjectById), new {id = 1}, model);
        }
        
        //PUT api/projects/1234
        [HttpPut("{id}")]
        public IActionResult PutProject(int id, UpdateProjectInputModel model)
        {
            return NoContent();
        }
        
        //DELETE api/projects/1234
        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            return NoContent();
        }
        
        //PUT api/projects/start/1234
        [HttpPut("start/{id}")]
        public IActionResult StartProject(int id)
        {
            return NoContent();
        }
        
        //PUT api/projects/complete/1234
        [HttpPut("complete/{id}")]
        public IActionResult CompleteProject(int id)
        {
            return NoContent();
        }
        
        //POST api/projects/comments/1234
        [HttpPost("comment/{id}")]
        public IActionResult PostComment(int id, CreateProjectCommentInputModel model)
        {
            return Ok();
        }
    }
}