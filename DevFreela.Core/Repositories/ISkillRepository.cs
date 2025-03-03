using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories;

public interface ISkillRepository
{
    Task<List<Skill>> GetAllAsync();
    Task<Skill?> GetByIdAsync(int id);
    Task<int> AddAsync(Skill skill);
}