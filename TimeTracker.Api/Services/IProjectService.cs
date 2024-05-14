using TimeTracker.Api.Controllers;
using TimeTracker.Shared.Models.Project;

namespace TimeTracker.Api.Services
{
    public interface IProjectService
    {
        Task<List<ProjectResponse>> CreateProject(ProjectCreateRequest request);
        Task<List<ProjectResponse>> GetAllProjects();
        Task<ProjectResponse?> GetProjectById(Guid id);
        Task<List<ProjectResponse>?> UpdateProject(Guid id, ProjectUpdateRequest request);
        Task<List<ProjectResponse>?> DeleteProject(Guid id);
    }
}