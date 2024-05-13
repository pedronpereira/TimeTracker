
namespace TimeTracker.Api.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _context;

        public ProjectRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetAllProjects()
        {
            return await _context.Projects
                .Include(p => p.ProjectDetails)
                .ToListAsync();
        }
    }
}
