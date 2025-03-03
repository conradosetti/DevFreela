using DevFreela.Application.Models;
using DevFreela.Application.Skills.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Skills.Queries.GetAllSkills;

public class GetAllSkillsQueryHandler(ISkillRepository repository) : IRequestHandler<GetAllSkillsQuery, ResultViewModel<List<AllSkillsViewModel>>>
{
    public async Task<ResultViewModel<List<AllSkillsViewModel>>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
    {
        var skills = await repository.GetAllAsync();
        var model = skills.Select(AllSkillsViewModel.FromEntity).ToList();
        
        return ResultViewModel<List<AllSkillsViewModel>>.Success(model);
    }
}