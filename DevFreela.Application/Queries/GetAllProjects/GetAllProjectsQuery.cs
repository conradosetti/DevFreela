using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.GetAllProjects;

public class GetAllProjectsQuery(string search) : IRequest<ResultViewModel<List<ProjectItemViewModel>>>
{
    public string Search { get; set; } = search;
}