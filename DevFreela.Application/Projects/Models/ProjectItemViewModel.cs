using DevFreela.Core.Entities;

namespace DevFreela.Application.Projects.Models;

public class ProjectItemViewModel(int id, string title, string clientName, string freelancerName, decimal totalCost)
{
    public int Id { get; private set; } = id;
    public string Title { get; private set; } = title;
    public string ClientName { get; private set; } = clientName;
    public string FreelancerName { get; private set; } = freelancerName;
    public decimal TotalCost { get; private set; } = totalCost;

    public static ProjectItemViewModel FromEntity(Project entity)
        => new(entity.Id, entity.Title, entity.Client.FullName,
            entity.FreeLancer.FullName, entity.TotalCost);
}