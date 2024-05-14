using Azure.Core;
using Mapster;
using TimeTracker.Api.Controllers;
using TimeTracker.Shared.Models.Project;

namespace TimeTracker.Api.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectResponse>> GetAllProjects()
        {
            var result = await _projectRepository.GetAllProjects();
            return result.Adapt<List<ProjectResponse>>();
        }

        public async Task<ProjectResponse?> GetProjectById(Guid id)
        {
            var result = await _projectRepository.GetProjectById(id);
            if (result is null) 
            {
                return null;
            }
            return result.Adapt<ProjectResponse>();
        }

        public async Task<List<ProjectResponse>> CreateProject(ProjectCreateRequest request)
        {
            var newEntry = request.Adapt<Project>();
            newEntry.ProjectDetails = request.Adapt<ProjectDetails>();
            var result = await _projectRepository.CreateProject(newEntry);
            return result.Adapt<List<ProjectResponse>>();
        }

        public async Task<List<ProjectResponse>?> UpdateProject(Guid id, ProjectUpdateRequest request)
        {
            try
            {
                var updateProject = request.Adapt<Project>();
                updateProject.ProjectDetails = request.Adapt<ProjectDetails>();
                var result = await _projectRepository.UpdateProject(id, updateProject);
                return result.Adapt<List<ProjectResponse>>();
            }
            catch (EntityNotFoundException)
            {
                return null;
            }
        }

        public async Task<List<ProjectResponse>?> DeleteProject(Guid id)
        {
            var result = await _projectRepository.DeleteProject(id);
            if (result is null)
            {
                return null;
            }
            return result.Adapt<List<ProjectResponse>>();
        }
    }
}
