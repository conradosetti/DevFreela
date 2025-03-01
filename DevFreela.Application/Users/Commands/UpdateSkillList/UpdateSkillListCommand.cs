using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Users.Commands.UpdateSkillList;

public class UpdateSkillListCommand : IRequest<ResultViewModel>
{
    public int UserId { get; set; }
    public int[] SkillIds { get; set; }
}