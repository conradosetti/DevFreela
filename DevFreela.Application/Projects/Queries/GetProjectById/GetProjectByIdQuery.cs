using DevFreela.Application.Models;
using DevFreela.Application.Projects.Models;
using MediatR;

namespace DevFreela.Application.Projects.Queries.GetProjectById;

public class GetProjectByIdQuery(int id) : IRequest<ResultViewModel<ProjectViewModel>>
{
    public int Id { get; set; } = id;
}