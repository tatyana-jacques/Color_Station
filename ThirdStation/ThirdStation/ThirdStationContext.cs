using Microsoft.EntityFrameworkCore;
namespace ThirdStation
{
    public class ThirdStationContext: DbContext
    {
        public ThirdStationContext(DbContextOptions<ThirdStationContext> options) : base(options) { }

        public DbSet<Passenger> Passengers { get; set; }
       
    }
}
