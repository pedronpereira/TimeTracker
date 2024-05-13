
namespace TimeTracker.Api.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllProjects();
        Task<Project?> GetProjectById(Guid id);
    }
}