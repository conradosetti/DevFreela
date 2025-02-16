namespace DevFreela.API.Entities;

public class User : BaseEntity
{
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public bool IsActive { get; private set; } = true;
    public List<UserSkill> UserSkills { get; private set; } = [];
    public List<ProjectComment> Comments { get; private set; } = [];
    public List<Project> OwnedProjects { get; private set; } = [];
    public List<Project> FreeLanceProjects { get; private set; } = [];

    public User(string fullName, string email, DateTime birthDate) : base()
    {
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
    }
}