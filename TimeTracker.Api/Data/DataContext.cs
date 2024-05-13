namespace TimeTracker.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeEntry>().Navigation(te => te.Project).AutoInclude();
            modelBuilder.Entity<Project>().Navigation(te => te.ProjectDetails).AutoInclude();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TimeEntry> TimeEntries { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectDetails> ProjectsDetails { get; set; }
        public DbSet<User> Users{ get; set; }
    }
}
