using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Projects.Commands.StartProject;

public class StartProjectHandler(DevFreelaDbContext context) : IRequestHandler<StartProjectCommand, ResultViewModel>
{
    public async Task<ResultViewModel> Handle(StartProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await context.Projects.SingleOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (project is null)
        {
            return ResultViewModel.Error("No project found");
        }
        project.Start();
        context.Projects.Update(project);
        await context.SaveChangesAsync(cancellationToken);
        
        return ResultViewModel.Success();
    }
}