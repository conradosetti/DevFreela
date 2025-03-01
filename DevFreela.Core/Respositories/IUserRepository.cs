using DevFreela.Core.Entities;

namespace DevFreela.Core.Respositories;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(int id);
    Task<int> CreateUserAsync(User user);
    Task UpdateSkillListAsync(List<UserSkill> userSkills);
}