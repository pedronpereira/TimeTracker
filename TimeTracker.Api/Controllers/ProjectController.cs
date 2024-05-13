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
    }
}
