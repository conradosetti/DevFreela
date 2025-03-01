using MediatR;

namespace DevFreela.Application.Projects.Notification.ProjectCreated;

public class FreeLanceNotificationHandler : INotificationHandler<ProjectCreatedNotification>
{
    public Task Handle(ProjectCreatedNotification notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Notificando os freeLancers sobre os projetos {notification.Title}"); //notificação de exemplo
        return Task.CompletedTask;
    }
}