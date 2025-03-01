using DevFreela.Application.Projects.Commands.CompleteProject;
using DevFreela.Application.Projects.Commands.DeleteProject;
using DevFreela.Application.Projects.Commands.InsertComment;
using DevFreela.Application.Projects.Commands.InsertProject;
using DevFreela.Application.Projects.Commands.StartProject;
using DevFreela.Application.Projects.Commands.UpdateProject;
using DevFreela.Application.Projects.Queries.GetAllProjects;
using DevFreela.Application.Projects.Queries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController(IMediator mediator) : ControllerBase
    {
        //GET api/projects?search=crm
        [HttpGet]
        public async Task<IActionResult> Get(string search = "")
        {
            var query = new ListProjects(search);
            var result = await mediator.Send(query);
            return Ok(result);
        }
        //GET api/projects/123
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            //var result = service.GetById(id);
            var query = new GetProjectByIdQuery(id);
            var result = await mediator.Send(query);
            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }
        // POST api/projects
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody]InsertProjectCommand command)
        {
            //var result = service.Insert(model);
            var result = await mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            
            
            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);

        }
        
        //PUT api/projects/1234
        [HttpPut("{id:int}")]
        public async Task< IActionResult> Update(int id, [FromBody]UpdateProjectCommand command)
        {
            command.Id = id;
            var result = await mediator.Send(command);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            return NoContent();
        }
        
        //DELETE api/projects/1234
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //var result = service.Delete(id);
            var result = await mediator.Send(new DeleteProjectCommand(id));
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return NoContent();
        }
        
        //PUT api/projects/start/1234
        [HttpPut("start/{id}")]
        public async Task<IActionResult> Start(int id)
        {
            //var result = service.Start(id);
            var result = await mediator.Send(new StartProjectCommand(id));
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            return NoContent();
        }
        
        //PUT api/projects/complete/1234
        [HttpPut("complete/{id:int}")]
        public async Task<IActionResult> Complete(int id)
        {
            //var result = service.Complete(id);
            var result = await mediator.Send(new CompleteProjectCommand(id));
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            return NoContent();
        }
        
        //POST api/projects/comments/1234
        [HttpPost("comments/{id}")]
        public async Task<IActionResult> InsertComment(int id, [FromBody]InsertCommentCommand command)
        {
            command.IdProject = id;
            //var result = service.InsertComment(id, model);
            var result = await mediator.Send(command);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            return NoContent();
        }
    }
}