using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCProtectionShared;
using PCProtectionShared.Data;

namespace PCProtectionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalyticsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AnalyticsController(AppDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetLatestMetrics()
        {
            var latestMetrics = await _context.SystemMetrics
                .OrderByDescending(m => m.CollectedAt)
                .Take(10)
                .ToListAsync();
            return Ok(latestMetrics);
        }



    }
}
