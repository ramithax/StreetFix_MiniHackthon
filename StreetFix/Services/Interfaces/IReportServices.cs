using StreetFix.Dtos;

namespace StreetFix.Services.Interfaces
{
    public interface IReportServices
    {
        Task<List<ReportDto>> GetAllReports();
        Task<ReportDto> GetReportById(int id);
        Task<ReportDto> CreateReport(ReportDto report);
        Task<ReportDto> UpdateReport(int id, ReportDto report);
        Task<bool> DeleteReport(int id);
    }
}