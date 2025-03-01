using DevFreela.Application.Models;
using DevFreela.Core.Respositories;
using MediatR;

namespace DevFreela.Application.Projects.Commands.DeleteProject;

public class DeleteProjectHandler(IProjectRepository repository) : IRequestHandler<DeleteProjectCommand, ResultViewModel>
{
    public async Task<ResultViewModel> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await repository.GetByIdAsync(request.Id);
        if (project is null)
        {
            return ResultViewModel.Error("No project found");
        }
        project.SetAsDeleted();
        await repository.UpdateAsync(project);
        
        return ResultViewModel.Success();
    }
}