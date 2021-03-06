using Microsoft.EntityFrameworkCore;

namespace BRestaurantReservation.Data
{
    public class RestaurantReservationContext : DbContext
    {
        public RestaurantReservationContext (DbContextOptions<RestaurantReservationContext> options)
            : base(options)
        {
        }
        public DbSet<DRestaurantReservation.MAvailableTables> MAvailableTables { get; set; }
        public DbSet<DRestaurantReservation.TTableReservation> TTableReservation { get; set; }
    }
}
