using DevFreela.API.Enums;

namespace DevFreela.API.Entities;

public class Project : BaseEntity
{
    public Project(){}
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int IdClient { get; private set; }
    public User Client { get; private set; }
    public int IdFreeLancer { get; private set; }
    public User FreeLancer { get; private set; }
    public decimal TotalCost { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    public ProjectStatusEnum Status { get; private set; }
    public List<ProjectComment> Comments { get; private set; }

    public Project(string title, string description, int idClient, int idFreeLancer, decimal totalCost) : base()
    {
        Title = title;
        Description = description;
        IdClient = idClient;
        IdFreeLancer = idFreeLancer;
        TotalCost = totalCost;

        Status = ProjectStatusEnum.Created;
        Comments = [];
    }

    public void Cancel()
    {
        if (Status is not (ProjectStatusEnum.Completed or ProjectStatusEnum.Cancelled))
        {
            Status = ProjectStatusEnum.Cancelled;
            FinishedAt = DateTime.Now;
        }
    }

    public void Start()
    {
        if (Status is not ProjectStatusEnum.Created) return;
        Status = ProjectStatusEnum.InProgress;
        StartedAt = DateTime.Now;
    }

    public void Complete()
    {
        if (Status is ProjectStatusEnum.PendingPayment or ProjectStatusEnum.InProgress)
        {
            Status = ProjectStatusEnum.Completed;
            FinishedAt = DateTime.Now;
        }
    }

    public void SetPendingPayment()
    {
        if (Status is ProjectStatusEnum.InProgress)
        {
            Status = ProjectStatusEnum.PendingPayment;
        }
    }

    public void Suspend()
    {
        if (Status is ProjectStatusEnum.InProgress)
        {
            Status = ProjectStatusEnum.Suspended;
        }
    }

    public void UnSuspend()
    {
        if (Status is ProjectStatusEnum.Suspended)
        {
            Status = ProjectStatusEnum.InProgress;
        }
    }

    public void Update(string title, string description, decimal totalCost)
    {
        Title = title;
        Description = description;
        TotalCost = totalCost;
    }
}