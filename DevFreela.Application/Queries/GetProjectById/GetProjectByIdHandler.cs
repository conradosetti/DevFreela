using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetProjectById;

public class GetProjectByIdHandler(DevFreelaDbContext context) : IRequestHandler<GetProjectByIdQuery, ResultViewModel<ProjectViewModel>>
{
    public async Task<ResultViewModel<ProjectViewModel>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await context.Projects
            .Include(p=>p.Client)
            .Include(p=>p.FreeLancer)
            .Include(p => p.Comments)
            .SingleOrDefaultAsync(p => p.Id == request.Id && p.IsDeleted == false, cancellationToken: cancellationToken);

        if (project == null) return ResultViewModel<ProjectViewModel>.Error("No project found");
        var model = ProjectViewModel.FromEntity(project);
        
        return ResultViewModel<ProjectViewModel>.Success(model);
    }
}