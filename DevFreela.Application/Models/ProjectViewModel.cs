using DevFreela.Core.Entities;

namespace DevFreela.Application.Models;

public class ProjectViewModel
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int IdCLient { get; private set; }
    public int IdFreeLancer { get; private set; }
    public string ClientName { get; private set; }
    public string FreelancerName { get; private set; }
    public decimal TotalCost { get; private set; }
    public List<string> Comments { get; private set; }

    public ProjectViewModel(int id, string title, string description, int idCLient, int idFreeLancer, string clientName, string freelancerName, decimal totalCost, List<ProjectComment> comments)
    {
        Id = id;
        Title = title;
        Description = description;
        IdCLient = idCLient;
        IdFreeLancer = idFreeLancer;
        ClientName = clientName;
        FreelancerName = freelancerName;
        TotalCost = totalCost;
        Comments = comments.Select(c => c.Content).ToList();
    }
    
    public static ProjectViewModel FromEntity(Project entity)
    => new(entity.Id, entity.Title, entity.Description,
        entity.IdClient, entity.IdFreeLancer, entity.Client.FullName, 
        entity.FreeLancer.FullName, entity.TotalCost, entity.Comments);
} 