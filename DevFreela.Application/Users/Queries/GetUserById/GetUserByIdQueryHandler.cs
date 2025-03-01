using DevFreela.Application.Models;
using DevFreela.Application.Users.Models;
using DevFreela.Core.Respositories;
using MediatR;

namespace DevFreela.Application.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler(IUserRepository repository) : IRequestHandler<GetUserByIdQuery, ResultViewModel<SingleUserViewModel>>
{
    public async Task<ResultViewModel<SingleUserViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await repository.GetUserByIdAsync(request.Id);
        if (user == null)
            return ResultViewModel<SingleUserViewModel>.Error("No user found");

        var model = SingleUserViewModel.FromEntity(user);
        return ResultViewModel<SingleUserViewModel>.Success(model);
    }
}