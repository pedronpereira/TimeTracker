namespace TimeTracker.Shared.Entities
{
    public class User
    {
        public string Id { get; set; }
        public required string Name { get; set; }
        public List<Project> Projects { get; set; } = new List<Project>();
    }
}
