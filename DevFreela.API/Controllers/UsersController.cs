using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/users")]

    public class UsersController(DevFreelaDbContext context) : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = context.Users
                .Include(u=>u.UserSkills)
                .ThenInclude(us=>us.Skill)
                .FirstOrDefault(u => u.Id == id && !u.IsDeleted);
            if (user == null)
            {
                return NotFound();
            }

            var model = SingleUserViewModel.FromEntity(user);
            return Ok(model);
        }
        // POST api/users
        [HttpPost]
        public IActionResult Post(CreateUserInputModel model)
        {
            var user = model.ToEntity();
            context.Users.Add(user);
            context.SaveChanges();
            return NoContent(); 
        }

        [HttpPut("{id:int}/skills")]
        public IActionResult PutSkill(int id, CreateUserSkillsInputModel model)
        {
            var userSkills = model.SkillIds.Select(s=>new UserSkill(id, s)).ToList();
            context.UserSkills.AddRange(userSkills);
            context.SaveChanges();
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

