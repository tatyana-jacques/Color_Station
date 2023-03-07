using Microsoft.EntityFrameworkCore;
namespace ThirdStation
{
    public class Receive2Context : DbContext
    {
        public DbSet<Passenger> Passengers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ColorStation;Trusted_Connection=True;persist security info=True;");
    }

}
