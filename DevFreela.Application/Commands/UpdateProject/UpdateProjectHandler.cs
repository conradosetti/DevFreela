using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.UpdateProject;

public class UpdateProjectHandler(DevFreelaDbContext context) : IRequestHandler<UpdateProjectCommand, ResultViewModel>
{
    public async Task<ResultViewModel> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await context.Projects.SingleOrDefaultAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);
        if (project is null)
        {
            return ResultViewModel.Error("No project found");
        }
        project.Update(request.Title, request.Description, request.Cost);
        context.Projects.Update(project);
        await context.SaveChangesAsync(cancellationToken);
        
        return ResultViewModel.Success();
    }
}