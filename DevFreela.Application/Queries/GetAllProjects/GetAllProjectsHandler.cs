using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetAllProjects;

public class GetAllProjectsHandler(DevFreelaDbContext context) : IRequestHandler<GetAllProjectsQuery, ResultViewModel<List<ProjectItemViewModel>>>
{
    public async Task<ResultViewModel<List<ProjectItemViewModel>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = await context.Projects
            .Include(p=>p.Client)
            .Include(p=>p.FreeLancer)
            .Include(p => p.Comments)
            .Where(p=>!p.IsDeleted && 
                      (request.Search == "" || p.Title.Contains(request.Search) || p.Description.Contains(request.Search)))
            //.Skip(page * pageSize)
            //.Take(pageSize)
            .ToListAsync(cancellationToken: cancellationToken);
        var model = projects.Select(ProjectItemViewModel.FromEntity).ToList();

        return ResultViewModel<List<ProjectItemViewModel>>.Success(model);
    }
}