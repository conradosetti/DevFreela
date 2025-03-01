using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Respositories;
using MediatR;

namespace DevFreela.Application.Users.Commands.UpdateSkillList;

public class UpdateSkillListCommandHandler(IUserRepository repository) : IRequestHandler<UpdateSkillListCommand, ResultViewModel>
{
    public async Task<ResultViewModel> Handle(UpdateSkillListCommand request, CancellationToken cancellationToken)
    {
        var userSkills = request.SkillIds.Select(s=>new UserSkill(request.UserId, s)).ToList();
        await repository.UpdateSkillListAsync(userSkills);
        
        return ResultViewModel.Success();
    }
}