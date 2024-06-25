using Microsoft.EntityFrameworkCore;

namespace Prueba_Tecnica_NetForemost.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<AsignacionSaldosGestores> AsignacionSaldosGestores { get; set; }
    }
}
