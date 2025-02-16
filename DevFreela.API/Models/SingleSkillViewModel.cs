using DevFreela.API.Entities;

namespace DevFreela.API.Models;

public class SingleSkillViewModel
{
    public int Id { get; private set; }
    public string Description { get; private set; }
    public string[] Users { get; private set; }

    public SingleSkillViewModel(int id, string description, string[] users)
    {
        Id = id;
        Description = description;
        Users = users;
    }

    public static SingleSkillViewModel FromEntity(Skill skill) =>
        new (skill.Id, skill.Description, skill.UserSkills.Select(u => u.User.FullName).ToArray());
}