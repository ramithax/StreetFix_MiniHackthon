using Microsoft.EntityFrameworkCore;
using StreetFix.Data;
using StreetFix.Dtos;
using StreetFix.Models;
using StreetFix.Services.Interfaces;

namespace StreetFix.Services
{
    public class ReportServices : IReportServices
    {
        private readonly AppDbContext _context;

        public ReportServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReportDto>> GetAllReports()
        {
            return await _context.Report
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => new ReportDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    Severity = r.Severity,
                    Location = r.Location,
                    ImageUrl = r.ImageUrl
                })
                .ToListAsync();
        }

        public async Task<ReportDto> GetReportById(int id)
        {
            var report = await _context.Report.FindAsync(id);
            if (report == null)
            {
                throw new KeyNotFoundException($"Report with ID {id} was not found.");
            }

            return new ReportDto
            {
                Id = report.Id,
                Name = report.Name,
                Description = report.Description,
                Severity = report.Severity,
                Location = report.Location,
                ImageUrl = report.ImageUrl
            };
        }

        public async Task<ReportDto> CreateReport(ReportDto report)
        {
            ArgumentNullException.ThrowIfNull(report);

            var newReport = new Report
            {
                Name = report.Name,
                Description = report.Description,
                Severity = report.Severity,
                Location = report.Location,
                ImageUrl = report.ImageUrl,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Report.Add(newReport);
            await _context.SaveChangesAsync();

            report.Id = newReport.Id;
            return report;
        }

        public async Task<ReportDto> UpdateReport(int id, ReportDto report)
        {
            ArgumentNullException.ThrowIfNull(report);

            var existingReport = await _context.Report.FindAsync(id);
            if (existingReport == null)
            {
                throw new KeyNotFoundException($"Report with ID {id} was not found.");
            }

            existingReport.Name = report.Name;
            existingReport.Description = report.Description;
            existingReport.Severity = report.Severity;
            existingReport.Location = report.Location;
            existingReport.ImageUrl = report.ImageUrl;
            existingReport.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new ReportDto
            {
                Id = existingReport.Id,
                Name = existingReport.Name,
                Description = existingReport.Description,
                Severity = existingReport.Severity,
                Location = existingReport.Location,
                ImageUrl = existingReport.ImageUrl
            };
        }

        public async Task<bool> DeleteReport(int id)
        {
            var report = await _context.Report.FindAsync(id);
            if (report == null)
            {
                return false;
            }

            _context.Report.Remove(report);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}