using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Controllers
{

    [ApiController]
    [Route("api/skills")]

    public class SkillsController(DevFreelaDbContext context) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllSkills()
        {
            var skills = context.Skills
                .Where(s=>s.IsDeleted == false)
                .ToList();
            var model = skills.Select(AllSkillsViewModel.FromEntity).ToList();
            return Ok(model);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var skills = context.Skills
                .Include(s=>s.UserSkills)
                .ThenInclude(us=>us.User)
                .Where(s => s.IsDeleted == false && s.Id == id).ToList();
            var model = skills.Select(SingleSkillViewModel.FromEntity).ToList();
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post(CreateSkillInputModel model)
        {
            var skill = model.ToEntity();
            context.Skills.Add(skill);
            context.SaveChanges();
            return NoContent();
        }
    }
}