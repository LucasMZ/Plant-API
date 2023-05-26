using Microsoft.EntityFrameworkCore;
namespace PlantApi.Data
{
    public class PlantContext: DbContext
    {
        public PlantContext(DbContextOptions<PlantContext> opts) : base (opts) { 
        }
        public DbSet<Controllers.PlantInfo> Plant { get; set; }
        public object PlantInfo { get; internal set; }
    }
}
