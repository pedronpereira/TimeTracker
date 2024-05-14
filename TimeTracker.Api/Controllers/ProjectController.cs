using Microsoft.AspNetCore.Mvc;
using TimeTracker.Shared.Models.Project;

namespace TimeTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectResponse>>> GetAllProjects()
        {
            return Ok(await _projectService.GetAllProjects());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectResponse>> GetProject(Guid id)
        {
            var result = await _projectService.GetProjectById(id);
            if (result == null)
            {
                return NotFound("Project with the given ID was not found");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<ProjectResponse>>> CreateProject(ProjectCreateRequest request)
        {
            return Ok(await _projectService.CreateProject(request));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ProjectResponse>>> UpdateProject(Guid id, ProjectUpdateRequest projectRequest)
        {
            var result = await _projectService.UpdateProject(id, projectRequest);
            if (result is null)
            {
                return NotFound("Project with the given ID was not found");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ProjectResponse>>> DeleteProject(Guid id)
        {
            var result = await _projectService.DeleteProject(id);
            if (result is null)
            {
                return NotFound("Project with the given ID was not found");
            }
            return Ok(result);
        }
    }
}
