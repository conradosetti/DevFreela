using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class SkillRepository(DevFreelaDbContext context) : ISkillRepository
{
    public async Task<List<Skill>> GetAllAsync()
    {
        var skills =  await context.Skills
            .Where(s=>s.IsDeleted == false)
            .ToListAsync();
        
        return skills;
    }

    public async Task<Skill?> GetByIdAsync(int id)
    {
        var skills = await context.Skills
            .Include(s=>s.UserSkills)
            .ThenInclude(us=>us.User)
            .SingleOrDefaultAsync(s => s.IsDeleted == false && s.Id == id);
        return skills;
    }

    public async Task<int> AddAsync(Skill skill)
    {
        await context.Skills.AddAsync(skill);
        await context.SaveChangesAsync();
        return skill.Id;
    }
}