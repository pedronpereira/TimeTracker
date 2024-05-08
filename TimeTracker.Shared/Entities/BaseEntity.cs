namespace TimeTracker.Shared.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime? DateUpdated { get; set; }
    }
}
