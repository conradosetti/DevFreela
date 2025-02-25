using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.InsertProject;

public class ValidateInsertProjectCommandBehavior(DevFreelaDbContext context)
: IPipelineBehavior<InsertProjectCommand, ResultViewModel<int>>
{
    public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
    {
        var clientExists = await context.Users.AnyAsync(u => u.Id == request.IdClient, cancellationToken: cancellationToken);
        var freeLancerExists = await context.Users.AnyAsync(u => u.Id == request.IdFreeLancer, cancellationToken: cancellationToken);

        if (!(clientExists && freeLancerExists))
            return ResultViewModel<int>.Error("Cliente ou Freelancer invalidos.");

        return await next();
    }
}