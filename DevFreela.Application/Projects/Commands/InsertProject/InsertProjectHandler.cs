using DevFreela.Application.Models;
using DevFreela.Application.Projects.Notification.ProjectCreated;
using DevFreela.Core.Respositories;
using MediatR;

namespace DevFreela.Application.Projects.Commands.InsertProject;

public class InsertProjectHandler(IMediator mediator, IProjectRepository repository) : IRequestHandler<InsertProjectCommand, ResultViewModel<int>>
{
    public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, CancellationToken cancellationToken)
    {
        var project = request.ToEntity();
    
        await repository.AddAsync(project);
        
        var projectCreated = new ProjectCreatedNotification(project.Id, project.Title, project.TotalCost); 
        await  mediator.Publish(projectCreated, cancellationToken);
        
        return ResultViewModel<int>.Success(project.Id); // Return the created project
    }
}