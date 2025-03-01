using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Projects.Commands.InsertProject;

public class InsertProjectCommand : IRequest<ResultViewModel<int>>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int IdClient { get; set; }
    public int IdFreeLancer { get; set; }
    public decimal Cost { get; set; }

    public Project ToEntity() =>
        new (Title, Description, IdClient, IdFreeLancer, Cost);
}