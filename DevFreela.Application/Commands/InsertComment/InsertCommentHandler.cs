using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.InsertComment;

public class InsertCommentHandler(DevFreelaDbContext context) : IRequestHandler<InsertCommentCommand, ResultViewModel>
{
    public  async Task<ResultViewModel> Handle(InsertCommentCommand request, CancellationToken cancellationToken)
    {
        var project = await context.Projects.SingleOrDefaultAsync(p => p.Id == request.IdProject, cancellationToken: cancellationToken);
        if (project is null)
        {
            return ResultViewModel.Error("No project found");
        }

        var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);
        await context.Comments.AddAsync(comment, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        return ResultViewModel.Success();
    }
}