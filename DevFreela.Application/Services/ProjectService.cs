using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services;

public class ProjectService(DevFreelaDbContext context) : IProjectService
{
    public ResultViewModel<List<ProjectItemViewModel>> GetAll(string search = "")
    {
        var projects = context.Projects
            .Include(p=>p.Client)
            .Include(p=>p.FreeLancer)
            .Include(p => p.Comments)
            .Where(p=>!p.IsDeleted && 
                      (search == "" || p.Title.Contains(search) || p.Description.Contains(search)))
            //.Skip(page * pageSize)
            //.Take(pageSize)
            .ToList();
        var model = projects.Select(ProjectItemViewModel.FromEntity).ToList();

        return ResultViewModel<List<ProjectItemViewModel>>.Success(model);
    }

    public ResultViewModel<ProjectViewModel> GetById(int id)
    {
        var project = context.Projects
            .Include(p=>p.Client)
            .Include(p=>p.FreeLancer)
            .Include(p => p.Comments)
            .SingleOrDefault(p => p.Id == id && p.IsDeleted == false);

        if (project == null) return ResultViewModel<ProjectViewModel>.Error("No project found");
        var model = ProjectViewModel.FromEntity(project);
        
        return ResultViewModel<ProjectViewModel>.Success(model);
    }

    public ResultViewModel<Project>Insert(CreateProjectInputModel model)
    {
        var project = model.ToEntity();
    
        context.Projects.Add(project);
        context.SaveChanges();

        return ResultViewModel<Project>.Success(project); // Return the created project
    }

    public ResultViewModel Update(int id, UpdateProjectInputModel model)
    {
        var project = context.Projects.SingleOrDefault(p => p.Id == id);
        if (project is null)
        {
            return ResultViewModel.Error("No project found");
        }
        project.Update(model.Title, model.Description, model.Cost);
        context.Projects.Update(project);
        context.SaveChanges();
        
        return ResultViewModel.Success();
    }

    public ResultViewModel Delete(int id)
    {
        var project = context.Projects.SingleOrDefault(p => p.Id == id);
        if (project is null)
        {
            return ResultViewModel.Error("No project found");
        }
        project.SetAsDeleted();
        context.Projects.Update(project);
        context.SaveChanges();
        
        return ResultViewModel.Success();
    }

    public ResultViewModel Start(int id)
    {
        var project = context.Projects.SingleOrDefault(p => p.Id == id);
        if (project is null)
        {
            return ResultViewModel.Error("No project found");
        }
        project.Start();
        context.Projects.Update(project);
        context.SaveChanges();
        
        return ResultViewModel.Success();
    }

    public ResultViewModel Complete(int id)
    {
        var project = context.Projects.SingleOrDefault(p => p.Id == id);
        if (project is null)
        {
            return ResultViewModel.Error("No project found");
        }
        project.Complete();
        context.Projects.Update(project);
        context.SaveChanges();
        
        return ResultViewModel.Success();
    }

    public ResultViewModel InsertComment(int id, CreateProjectCommentInputModel model)
    {
        var project = context.Projects.SingleOrDefault(p => p.Id == id);
        if (project is null)
        {
            return ResultViewModel.Error("No project found");
        }

        var comment = model.ToEntity();
        context.Comments.Add(comment);
        context.SaveChanges();
        
        return ResultViewModel.Success();
    }
}