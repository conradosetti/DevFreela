using DevFreela.Application.Models;
using DevFreela.Application.Projects.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Projects.Queries.GetProjectById;

public class GetProjectByIdHandler(IProjectRepository repository) : IRequestHandler<GetProjectByIdQuery, ResultViewModel<ProjectViewModel>>
{
    public async Task<ResultViewModel<ProjectViewModel>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await repository.GetDetailsByIdAsync(request.Id);

        if (project == null) return ResultViewModel<ProjectViewModel>.Error("No project found");
        var model = ProjectViewModel.FromEntity(project);
        
        return ResultViewModel<ProjectViewModel>.Success(model);
    }
}