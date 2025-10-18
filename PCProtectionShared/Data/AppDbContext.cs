using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PCProtectionShared.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<SystemMetric> SystemMetrics { get; set; }
    }
}
