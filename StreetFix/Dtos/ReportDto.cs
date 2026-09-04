using StreetFix.Models;

namespace StreetFix.Dtos
{
    public class ReportDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public Severity Severity { get; set; }

        public string Location { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}