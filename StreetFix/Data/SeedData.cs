using StreetFix.Models;

namespace StreetFix.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            // Don't seed if data already exists
            if (context.Report.Any())
            {
                return;
            }

            var reports = new List<Report>
            {
                new Report
                {
                    Name = "Large pothole on main road",
                    Description = "A large pothole has appeared on the main road and is causing difficulties for vehicles.",
                    Severity = Severity.High,
                    Location = "Kandy Road, Peradeniya",
                    ImageUrl = "https://images.unsplash.com/photo-1517999144091-3d9dca6d1f6e",
                    CreatedAt = DateTime.UtcNow.AddDays(-5),
                    UpdatedAt = DateTime.UtcNow.AddDays(-2)
                },

                new Report
                {
                    Name = "Broken street light",
                    Description = "The street light near the bus stop is not working during the night.",
                    Severity = Severity.Medium,
                    Location = "Kandy City Centre",
                    ImageUrl = "https://images.unsplash.com/photo-1519501025264-65ba15a82390",
                    CreatedAt = DateTime.UtcNow.AddDays(-4),
                    UpdatedAt = DateTime.UtcNow.AddDays(-3)
                },

                new Report
                {
                    Name = "Garbage accumulation",
                    Description = "Garbage has been accumulating near the roadside for several days.",
                    Severity = Severity.Medium,
                    Location = "Katugastota Road",
                    ImageUrl = "https://images.unsplash.com/photo-1532996122724-e3c354a0b15b",
                    CreatedAt = DateTime.UtcNow.AddDays(-3),
                    UpdatedAt = DateTime.UtcNow.AddDays(-1)
                },

                new Report
                {
                    Name = "Damaged pedestrian walkway",
                    Description = "Several sections of the pedestrian walkway are damaged and difficult to use.",
                    Severity = Severity.High,
                    Location = "Peradeniya Road",
                    ImageUrl = "https://images.unsplash.com/photo-1494526585095-c41746248156",
                    CreatedAt = DateTime.UtcNow.AddDays(-7),
                    UpdatedAt = DateTime.UtcNow.AddDays(-5)
                },

                new Report
                {
                    Name = "Blocked drainage system",
                    Description = "The roadside drainage is blocked with leaves and waste, causing water to collect.",
                    Severity = Severity.High,
                    Location = "Ampitiya Road",
                    ImageUrl = "https://images.unsplash.com/photo-1547683905-f686c993aae5",
                    CreatedAt = DateTime.UtcNow.AddDays(-6),
                    UpdatedAt = DateTime.UtcNow.AddDays(-4)
                },

                new Report
                {
                    Name = "Road sign damaged",
                    Description = "A road warning sign has been damaged and is difficult to read.",
                    Severity = Severity.Low,
                    Location = "William Gopallawa Mawatha",
                    ImageUrl = "https://images.unsplash.com/photo-1503594384566-461fe158e797",
                    CreatedAt = DateTime.UtcNow.AddDays(-2),
                    UpdatedAt = DateTime.UtcNow.AddDays(-2)
                },

                new Report
                {
                    Name = "Cracked road surface",
                    Description = "The road surface has several large cracks that may become dangerous if not repaired.",
                    Severity = Severity.Medium,
                    Location = "Rajapihilla Mawatha",
                    ImageUrl = "https://images.unsplash.com/photo-1533106418989-88406c7cc8ca",
                    CreatedAt = DateTime.UtcNow.AddDays(-8),
                    UpdatedAt = DateTime.UtcNow.AddDays(-6)
                },

                new Report
                {
                    Name = "Overflowing public garbage bin",
                    Description = "A public garbage bin is overflowing and waste is scattered around the area.",
                    Severity = Severity.Low,
                    Location = "Kandy Lake Road",
                    ImageUrl = "https://images.unsplash.com/photo-1604187351574-c75ca79f5807",
                    CreatedAt = DateTime.UtcNow.AddDays(-1),
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.Report.AddRange(reports);
            context.SaveChanges();
        }
    }
}