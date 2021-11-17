using DRestaurantReservation;
using Microsoft.EntityFrameworkCore;

namespace BRestaurantReservation.Data
{
    public class RestaurantReservationContext : DbContext
    {
        public RestaurantReservationContext (DbContextOptions<RestaurantReservationContext> options)
            : base(options)
        {
        }
        public DbSet<DRestaurantReservation.MAvaialbleTables> MAvaialbleTables { get; set; }
        public DbSet<DRestaurantReservation.TTableReservation> TTableReservation { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<TTableReservation>().HasNoKey();
        //    //modelBuilder.Entity<TTableReservation>(b =>
        //    // {                                 
        //    //                         b.Name();
        //    //                         b.ResDate(e => e.Label);
        //    //                         b.HasNoKey();
        //    //                         b.NumberOfPersons("_id");
        //    //                         b.TableId(e => e.Label);
        //    // });

        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly.Add(new TTableReservation());
            modelBuilder.Entity<TTableReservation>().HasNoKey();
        }



    }
}
