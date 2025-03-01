using DevFreela.Application.Models;
using DevFreela.Application.Projects.Models;
using MediatR;

namespace DevFreela.Application.Projects.Queries.GetAllProjects;

public class ListProjects(string search) : IRequest<ResultViewModel<List<ProjectItemViewModel>>>
{
    public string Search { get; set; } = search;
}