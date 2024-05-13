using TimeTracker.Shared.Models.Project;

namespace TimeTracker.Api.Services
{
    public interface IProjectService
    {
        Task<List<ProjectResponse>> GetAllProjects();
        Task<ProjectResponse?> GetProjectById(Guid id);
    }
}