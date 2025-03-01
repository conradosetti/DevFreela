using DevFreela.Application.Skills.Commands.InsertSkill;
using DevFreela.Application.Skills.Queries.GetAllSkills;
using DevFreela.Application.Skills.Queries.GetSkillByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{

    [ApiController]
    [Route("api/skills")]

    public class SkillsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await mediator.Send(new GetAllSkillsQuery());
            return Ok(results);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetSkillByIdQuery(id));
            if (!result.IsSuccess)
                return NotFound(result.Message);
            
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertSkillCommand command)
        {
            var result = await mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }
    }
}