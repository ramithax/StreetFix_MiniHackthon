using Microsoft.AspNetCore.Mvc;
using StreetFix.Dtos;
using StreetFix.Services.Interfaces;

namespace StreetFix.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportServices _reportServices;

        public ReportsController(IReportServices reportServices)
        {
            _reportServices = reportServices;
        }

        // GET: api/reports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportDto>>> GetAllReports()
        {
            return Ok(await _reportServices.GetAllReports());
        }

        // GET: api/reports/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ReportDto>> GetReportById(int id)
        {
            try
            {
                return Ok(await _reportServices.GetReportById(id));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/reports
        [HttpPost]
        public async Task<ActionResult<ReportDto>> CreateReport([FromBody] ReportDto report)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdReport = await _reportServices.CreateReport(report);
            return CreatedAtAction(nameof(GetReportById), new { id = createdReport.Id }, createdReport);
        }

        // PUT: api/reports/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ReportDto>> UpdateReport(int id, [FromBody] ReportDto report)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedReport = await _reportServices.UpdateReport(id, report);
                return Ok(updatedReport);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/reports/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            var deleted = await _reportServices.DeleteReport(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}