using Microsoft.EntityFrameworkCore;
using NextBike.Models;

namespace NextBike.Data
{
    public class NextBikeContext : DbContext
    {
        public NextBikeContext (DbContextOptions<NextBikeContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Bike> Bikes { get; set; }
    }
}
