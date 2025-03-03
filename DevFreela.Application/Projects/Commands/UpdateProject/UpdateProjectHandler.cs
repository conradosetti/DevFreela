using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Projects.Commands.UpdateProject;

public class UpdateProjectHandler(IProjectRepository repository) : IRequestHandler<UpdateProjectCommand, ResultViewModel>
{
    public async Task<ResultViewModel> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await repository.GetByIdAsync(request.Id);
        if (project is null)
        {
            return ResultViewModel.Error("No project found");
        }
        project.Update(request.Title, request.Description, request.Cost);
        await repository.UpdateAsync(project);
        
        return ResultViewModel.Success();
    }
}