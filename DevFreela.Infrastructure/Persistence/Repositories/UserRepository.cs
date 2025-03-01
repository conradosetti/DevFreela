using DevFreela.Core.Entities;
using DevFreela.Core.Respositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class UserRepository(DevFreelaDbContext context) : IUserRepository
{
    public async Task<User?> GetUserByIdAsync(int id)
    {
        var user = await context.Users
            .Include(u=>u.UserSkills)
            .ThenInclude(us=>us.Skill)
            .FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted);

        return user;
    }

    public async Task<int> CreateUserAsync(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return user.Id;
    }

    public async Task UpdateSkillListAsync(List<UserSkill> userSkills)
    {
        await context.UserSkills.AddRangeAsync(userSkills);
        await context.SaveChangesAsync();
    }
}