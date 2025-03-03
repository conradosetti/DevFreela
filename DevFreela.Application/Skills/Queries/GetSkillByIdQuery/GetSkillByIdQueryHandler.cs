using DevFreela.Application.Models;
using DevFreela.Application.Skills.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Skills.Queries.GetSkillByIdQuery;

public class GetSkillByIdQueryHandler(ISkillRepository repository) : IRequestHandler<GetSkillByIdQuery, ResultViewModel<SingleSkillViewModel>>
{
    public async Task<ResultViewModel<SingleSkillViewModel>> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
    {
        var skill = await repository.GetByIdAsync(request.Id);
        if (skill == null)
            return ResultViewModel<SingleSkillViewModel>.Error("No project found");
        var model = SingleSkillViewModel.FromEntity(skill);
        return ResultViewModel<SingleSkillViewModel>.Success(model);
    }
}