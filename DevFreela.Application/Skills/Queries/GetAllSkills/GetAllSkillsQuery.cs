using DevFreela.Application.Models;
using DevFreela.Application.Skills.Models;
using MediatR;

namespace DevFreela.Application.Skills.Queries.GetAllSkills;

public class GetAllSkillsQuery : IRequest<ResultViewModel<List<AllSkillsViewModel>>>
{
    
}