using DevFreela.Application.Models;
using DevFreela.Application.Projects.Models;
using DevFreela.Core.Respositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Projects.Queries.GetAllProjects;

public class ListProjectsHandler(IProjectRepository repository) : IRequestHandler<ListProjects, ResultViewModel<List<ProjectItemViewModel>>>
{
    public async Task<ResultViewModel<List<ProjectItemViewModel>>> Handle(ListProjects request, CancellationToken cancellationToken)
    {
        var projects = await repository.GetAllAsync(request.Search);
        var model = projects.Select(ProjectItemViewModel.FromEntity).ToList();

        return ResultViewModel<List<ProjectItemViewModel>>.Success(model);
    }
}