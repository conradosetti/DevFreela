using DevFreela.API.Entities;

namespace DevFreela.API.Models;

public class AllSkillsViewModel
{
    public int Id { get; private set; }
    public string Description { get; private set; }

    public AllSkillsViewModel(int id, string description)
    {
        Id = id;
        Description = description;
    }

    public static AllSkillsViewModel FromEntity(Skill skill)
        => new AllSkillsViewModel(skill.Id, skill.Description);
}