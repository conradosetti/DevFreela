using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Projects.Commands.CompleteProject;

public class CompleteProjectHandler(IProjectRepository repository) : IRequestHandler<CompleteProjectCommand, ResultViewModel>
{
    public async Task<ResultViewModel> Handle(CompleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await repository.GetByIdAsync(request.Id);
        if (project is null)
        {
            return ResultViewModel.Error("No project found");
        }
        project.Complete();
        await repository.UpdateAsync(project);
        
        return ResultViewModel.Success();
    }
}