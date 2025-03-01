using DevFreela.Application.Models;
using DevFreela.Core.Respositories;
using MediatR;

namespace DevFreela.Application.Users.Commands.InsertUser;

public class InsertUserCommandHandler(IUserRepository repository) : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
{
    public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        var user = request.ToEntity();
        await repository.CreateUserAsync(user);
        
        return ResultViewModel<int>.Success(user.Id);
    }
}