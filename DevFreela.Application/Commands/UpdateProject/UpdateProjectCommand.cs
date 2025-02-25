using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.UpdateProject;

public class UpdateProjectCommand(int id) : IRequest<ResultViewModel>
{
    public int Id { get; set; } = id;
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Cost { get; set; }
}