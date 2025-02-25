using DevFreela.Application.Models;
using DevFreela.Application.Notification.ProjectCreated;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.InsertProject;

public class InsertProjectHandler(DevFreelaDbContext context, IMediator mediator) : IRequestHandler<InsertProjectCommand, ResultViewModel<int>>
{
    public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, CancellationToken cancellationToken)
    {
        var project = request.ToEntity();
    
        await context.Projects.AddAsync(project, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        var projectCreated = new ProjectCreatedNotification(project.Id, project.Title, project.TotalCost); 
        await  mediator.Publish(projectCreated, cancellationToken);
        
        return ResultViewModel<int>.Success(project.Id); // Return the created project
    }
}