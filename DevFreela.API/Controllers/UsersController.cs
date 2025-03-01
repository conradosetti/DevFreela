using DevFreela.Application.Users.Commands.InsertUser;
using DevFreela.Application.Users.Commands.UpdateSkillList;
using DevFreela.Application.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/users")]

    public class UsersController(IMediator mediator) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetUserByIdQuery(id));
            if (!result.IsSuccess)
            {
                return NotFound();
            }
            return Ok(result);
        }
        // POST api/users
        [HttpPost]
        public async Task<IActionResult> Post(InsertUserCommand command)
        {
            var result = await mediator.Send(command);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpPut("{id:int}/skills")]
        public async  Task<IActionResult> PutSkill(int id, UpdateSkillListCommand command)
        {
            var result = await mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return NoContent();
        }
        
        //PUT api/users
        [HttpPut("/{id:int}profile-picture")]
        public IActionResult PutProfilePicture(int id, IFormFile file)
        {
            var description = $"File: {file.FileName}, Size: {file.Length}";
            
            //Process Image
            
            
            return Ok(description);
            
        }
    }
}

