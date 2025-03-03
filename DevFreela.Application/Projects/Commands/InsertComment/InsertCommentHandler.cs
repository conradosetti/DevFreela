using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Projects.Commands.InsertComment;

public class InsertCommentHandler(IProjectRepository repository) : IRequestHandler<InsertCommentCommand, ResultViewModel>
{
    public  async Task<ResultViewModel> Handle(InsertCommentCommand request, CancellationToken cancellationToken)
    {
        var projectExists = await repository.ExistsAsync(request.IdProject);
        if (projectExists is false)
        {
            return ResultViewModel.Error("No project found");
        }

        var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);
        await repository.AddCommentAsync(comment);
        
        return ResultViewModel.Success();
    }
}