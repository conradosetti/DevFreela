using DevFreela.API.Entities;

namespace DevFreela.API.Models;

public class SingleUserViewModel
{
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string[] Skills { get; private set; }

    public SingleUserViewModel(string fullName, string email, DateTime birthDate, string[] skills)
    {
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
        Skills = skills;
    }
    
    public static SingleUserViewModel FromEntity(User user)
    => new SingleUserViewModel(user.FullName, user.Email, user.BirthDate, user.UserSkills.Select(us=>us.Skill.Description).ToArray());
}