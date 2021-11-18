using BRestaurantReservation;
using BRestaurantReservation.Data;
using DRestaurantReservation;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;
namespace RestaurantReservationTest
{
    public class DatabaseIntializer : IDisposable
    {
        private static readonly object _lock = new object();
        private static bool _databaseInitialized;
        public DbConnection Connection { get; }
        public DatabaseIntializer()
        {
            Connection = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=ReservationTestDb;Trusted_Connection=True");
            Seed();
            Connection.Open();
        }
        public RestaurantReservationContext CreateContext(DbTransaction transaction = null)
        {
            var context = new RestaurantReservationContext(new DbContextOptionsBuilder<RestaurantReservationContext>().UseSqlServer(Connection).Options);
            if (transaction != null)
            {
                context.Database.UseTransaction(transaction);
            }
            return context;
        }
        public void Seed()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                        context.MAvaialbleTables.AddRange(
                        new MAvaialbleTables() { TCapacity = 2, TActive = 1 },
                        new MAvaialbleTables() { TCapacity = 6, TActive = 1 },
                        new MAvaialbleTables() { TCapacity = 6, TActive = 1 },
                        new MAvaialbleTables() { TCapacity = 6, TActive = 1 },
                        new MAvaialbleTables() { TCapacity = 12, TActive = 1 });
                        context.TTableReservation.AddRange(
                       new TTableReservation() { Name = "lava", ResDate = DateTime.Now.AddDays(3), NumberOfPersons = 2 });
                        context.SaveChanges();
                    }
                    _databaseInitialized = true;
                }
            }
        }
        public void Dispose() => Connection.Dispose();
    }

}



