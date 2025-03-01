using DevFreela.Core.Entities;

namespace DevFreela.Core.Respositories;

public interface IProjectRepository
{
    Task<List<Project>> GetAllAsync(string search);
    Task<Project?> GetDetailsByIdAsync(int id);
    Task<Project?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<int> AddAsync(Project project);
    Task UpdateAsync(Project project);
    Task AddCommentAsync(ProjectComment comment);
}