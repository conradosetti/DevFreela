using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class ProjectRepository(DevFreelaDbContext context) : IProjectRepository
{
    public async Task<List<Project>> GetAllAsync(string search)
    {
        var projects = await context.Projects
            .Include(p=>p.Client)
            .Include(p=>p.FreeLancer)
            .Include(p => p.Comments)
            .Where(p=>!p.IsDeleted && 
                      (search == "" || p.Title.Contains(search) || p.Description.Contains(search)))
            //.Skip(page * pageSize)
            //.Take(pageSize)
            .ToListAsync();
        
        return projects;
    }

    public async Task<Project?> GetDetailsByIdAsync(int id)
    {
        var project = await context.Projects
            .Include(p=>p.Client)
            .Include(p=>p.FreeLancer)
            .Include(p => p.Comments)
            .SingleOrDefaultAsync(p => p.Id == id && p.IsDeleted == false);
        
        return project;
    }

    public async Task<Project?> GetByIdAsync(int id)
    {
        return await context.Projects.SingleOrDefaultAsync(p => p.Id == id && p.IsDeleted == false);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await context.Projects.AnyAsync(p => p.Id == id);
    }

    public async Task<int> AddAsync(Project project)
    {
        await context.Projects.AddAsync(project);
        await context.SaveChangesAsync();
        
        return project.Id;
    }

    public async Task UpdateAsync(Project project)
    {
        context.Projects.Update(project);
        await context.SaveChangesAsync();
    }

    public async Task AddCommentAsync(ProjectComment comment)
    {
        await context.Comments.AddAsync(comment);
        await context.SaveChangesAsync();
    }
}