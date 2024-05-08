namespace TimeTracker.Shared.Entities
{
    public class ProjectDetails
    {
        public string Id { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? ProjectId { get; set; }
        public required Project Project { get; set; }
    }
}
