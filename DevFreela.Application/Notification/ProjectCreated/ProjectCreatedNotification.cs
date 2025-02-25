using MediatR;

namespace DevFreela.Application.Notification.ProjectCreated;

public class ProjectCreatedNotification(int projectId, string title, decimal totalCost) : INotification
{
    public int ProjectId { get; private set; } = projectId;
    public string Title { get; private set; } = title;
    public decimal TotalCost { get; private set; } = totalCost;
}