using DevFreela.Application.Models;
using DevFreela.Application.Users.Models;
using MediatR;

namespace DevFreela.Application.Users.Queries.GetUserById;

public class GetUserByIdQuery(int id) : IRequest<ResultViewModel<SingleUserViewModel>>
{
    public int Id { get; set; } = id;
}