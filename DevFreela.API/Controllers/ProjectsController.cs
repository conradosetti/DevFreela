using DevFreela.Application.Models;
using DevFreela.Application.Services;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController(IProjectService service) : ControllerBase
    {
        //GET api/projects?search=crm
        [HttpGet]
        public IActionResult Get(string search = "")
        {
            var result = service.GetAll(search);
            return Ok(result);
        }
        //GET api/projects/123
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = service.GetById(id);
            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }
        // POST api/projects
        [HttpPost]
        public IActionResult Insert(CreateProjectInputModel model)
        {
            var result = service.Insert(model);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            
            
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);

        }
        
        //PUT api/projects/1234
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, UpdateProjectInputModel model)
        {
            var result = service.Update(id, model);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            return NoContent();
        }
        
        //DELETE api/projects/1234
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            return NoContent();
        }
        
        //PUT api/projects/start/1234
        [HttpPut("start/{id}")]
        public IActionResult Start(int id)
        {
            var result = service.Start(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            return NoContent();
        }
        
        //PUT api/projects/complete/1234
        [HttpPut("complete/{id:int}")]
        public IActionResult Complete(int id)
        {
            var result = service.Complete(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            return NoContent();
        }
        
        //PUT api/projects/comments/1234
        [HttpPut("comments/{id}")]
        public IActionResult InsertComment(int id, CreateProjectCommentInputModel model)
        {
            var result = service.InsertComment(id, model);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            return NoContent();
        }
    }
}