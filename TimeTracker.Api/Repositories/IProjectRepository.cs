
namespace TimeTracker.Api.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> CreateProject(Project newEntry);
        Task<List<Project>> GetAllProjects();
        Task<Project?> GetProjectById(Guid id);
        Task<List<Project>?> UpdateProject(Guid id, Project project);
        Task<List<Project>?> DeleteProject(Guid id);
    }
}