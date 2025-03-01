using DevFreela.Application.Models;
using DevFreela.Core.Respositories;
using MediatR;

namespace DevFreela.Application.Skills.Commands.InsertSkill;

public class InsertSkillCommandHandler(ISkillRepository repository) : IRequestHandler<InsertSkillCommand, ResultViewModel<int>>
{
    public async Task<ResultViewModel<int>> Handle(InsertSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = request.ToEntity();
        await repository.AddAsync(skill);
        
        return ResultViewModel<int>.Success(skill.Id);
    }
}