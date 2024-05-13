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
    }
}
