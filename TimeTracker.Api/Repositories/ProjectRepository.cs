

using TimeTracker.Shared.Entities;

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
                .Where(p => !p.IsDeleted)
                .Include(p => p.ProjectDetails)
                .ToListAsync();
        }

        public async Task<Project?> GetProjectById(Guid id)
        {
            return await _context.Projects
                .Where(p => !p.IsDeleted)
                .Include(p => p.ProjectDetails)
                .FirstOrDefaultAsync(p => p.Id == id.ToString());
        }

        public async Task<List<Project>> CreateProject(Project newEntry)
        {
            newEntry.Id = Guid.NewGuid().ToString();
            if (newEntry.ProjectDetails != null)
            {
                newEntry.ProjectDetails.Id = Guid.NewGuid().ToString();
            }

            _context.Projects.Add(newEntry);
            await _context.SaveChangesAsync();

            return await GetAllProjects();
        }

        public async Task<List<Project>?> UpdateProject(Guid id, Project project)
        {
            var dbProject = await _context.Projects.FindAsync(id.ToString());
            if (dbProject is null)
            {
                throw new EntityNotFoundException($"Entity with id:{id} not found.");
            }


            if (project.ProjectDetails != null && dbProject.ProjectDetails != null)
            {
                dbProject.ProjectDetails.Description = project.ProjectDetails.Description;
                dbProject.ProjectDetails.StartDate = project.ProjectDetails.StartDate;
                dbProject.ProjectDetails.EndDate = project.ProjectDetails.EndDate;
            }
            else if (project.ProjectDetails != null && dbProject.ProjectDetails == null)
            {
                dbProject.ProjectDetails = new ProjectDetails
                {
                    Id = Guid.NewGuid().ToString(),
                    Description = project.ProjectDetails.Description,
                    StartDate = project.ProjectDetails.StartDate,
                    EndDate = project.ProjectDetails.EndDate,
                    Project = project
                };
            }

            dbProject.Name = project.Name;
            dbProject.DateUpdated = DateTime.Now;
            await _context.SaveChangesAsync();

            return await GetAllProjects();
        }

        public async Task<List<Project>?> DeleteProject(Guid id)
        {
            var dbProject = await _context.Projects.FindAsync(id.ToString());
            if (dbProject is null)
            {
                return null;
            }

            dbProject.IsDeleted = true;
            dbProject.DateDeleted = DateTime.Now;

            await _context.SaveChangesAsync();
            return await GetAllProjects();
        }
    }
}
