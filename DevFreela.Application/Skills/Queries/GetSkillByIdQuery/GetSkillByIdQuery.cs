using DevFreela.Application.Models;
using DevFreela.Application.Skills.Models;
using MediatR;

namespace DevFreela.Application.Skills.Queries.GetSkillByIdQuery;

public class GetSkillByIdQuery(int id) : IRequest<ResultViewModel<SingleSkillViewModel>>
{
    public int Id { get; set; } = id;
}