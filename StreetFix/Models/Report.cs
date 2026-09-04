namespace StreetFix.Models
{
    public class Report
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public Severity Severity { get; set; }

        public string Location { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum Severity
    {
        Low,
        Medium,
        High
    }
}