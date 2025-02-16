using DevFreela.API.Models;
using DevFreela.API.Persistence;
using DevFreela.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectsController(DevFreelaDbContext context) : ControllerBase
    {
        //GET api/projects?search=crm
        [HttpGet]
        public IActionResult GetAllProjects(string search = "", int page = 0, int pageSize = 3)
        {
            var projects = context.Projects
                .Include(p=>p.Client)
                .Include(p=>p.FreeLancer)
                .Include(p => p.Comments)
                .Where(p=>!p.IsDeleted && 
                          (search == "" || p.Title.Contains(search) || p.Description.Contains(search)))
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
            
            var model = projects.Select(ProjectItemViewModel.FromEntity).ToList();
            
            return Ok(model);
        }
        //GET api/projects/123
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = context.Projects
                .Include(p=>p.Client)
                .Include(p=>p.FreeLancer)
                .Include(p => p.Comments)
                .SingleOrDefault(p => p.Id == id && p.IsDeleted == false);
            
            var model = project != null ? ProjectViewModel.FromEntity(project) : null;
            return Ok(model);
        }
        // POST api/projects
        [HttpPost]
        public IActionResult Post(CreateProjectInputModel model)
        {
            var project = model.ToEntity();
            
            context.Projects.Add(project);
            context.SaveChanges();
            
            
            return CreatedAtAction(nameof(GetById), new {id = project.Id}, context.Projects.SingleOrDefault(p => p.Id == project.Id));
        }
        
        //PUT api/projects/1234
        [HttpPut("{id}")]
        public IActionResult PutProject(int id, UpdateProjectInputModel model)
        {
            var project = context.Projects.SingleOrDefault(p => p.Id == id);
            if (project is null)
            {
                return NotFound();
            }
            project.Update(model.Title, model.Description, model.Cost);
            context.Projects.Update(project);
            context.SaveChanges();
            return NoContent();
        }
        
        //DELETE api/projects/1234
        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var project = context.Projects.SingleOrDefault(p => p.Id == id);
            if (project is null)
            {
                return NotFound();
            }
            project.SetAsDeleted();
            context.Projects.Update(project);
            context.SaveChanges();
            
            return NoContent();
        }
        
        //PUT api/projects/start/1234
        [HttpPut("start/{id}")]
        public IActionResult StartProject(int id)
        {
            var project = context.Projects.SingleOrDefault(p => p.Id == id);
            if (project is null)
            {
                return NotFound();
            }
            project.Start();
            context.Projects.Update(project);
            context.SaveChanges();
            
            return NoContent();
        }
        
        //PUT api/projects/complete/1234
        [HttpPut("complete/{id}")]
        public IActionResult CompleteProject(int id)
        {
            var project = context.Projects.SingleOrDefault(p => p.Id == id);
            if (project is null)
            {
                return NotFound();
            }
            project.Complete();
            context.Projects.Update(project);
            context.SaveChanges();
            
            return NoContent();
        }
        
        //PUT api/projects/comments/1234
        [HttpPut("comment/{id}")]
        public IActionResult PutComment(int id, CreateProjectCommentInputModel model)
        {
            var project = context.Projects.SingleOrDefault(p => p.Id == id);
            if (project is null)
            {
                return NotFound();
            }

            var comment = model.ToEntity();
            context.Comments.Add(comment);
            context.SaveChanges();
            
            return Ok();
        }
    }
}