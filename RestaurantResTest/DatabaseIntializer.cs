using BRestaurantRes;
using BRestaurantRes.Data;
using DRestautrantRes;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ResetaurantRes.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RestaurantResTest
{
 public  class DatabaseIntializer:IDisposable
    {
        
            private static readonly object _lock = new object();
            private static bool _databaseInitialized;
            private readonly IRestableResvation _restableResvation;

        

        public DatabaseIntializer()
        {
            Connection = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Trusted_Connection=True");


            Seed();

            Connection.Open();
        }

          public DbConnection Connection { get; }
        public ResetaurantResContext CreateContext(DbTransaction transaction = null)
        {
            var context = new ResetaurantResContext(new DbContextOptionsBuilder<ResetaurantResContext>().UseSqlServer(Connection).Options);

            if (transaction != null)
            {
                context.Database.UseTransaction(transaction);
            }

            return context;
        }

        //public ResetaurantResContext CreateContext(DbTransaction transaction = null)
        //    {
        //         var context  = new ResetaurantResContext(new DbContextOptionsBuilder<ResetaurantResContext>()
        //         .UseSqlServer("Data Source=LAPTOP-LR3RK1IO\\SQLEXPRESS;Initial Catalog=restaurant;Integrated Security=True;Pooling=False").Options);

        //    if (transaction != null)
        //        {
        //            context.Database.UseTransaction(transaction);
        //        }

        //        return context;
        //}
    
            public void Seed()
            {

                    using (var context = CreateContext())
                    {
                        context.Database.EnsureCreated();
                        context.Database.EnsureDeleted();
                        context.MTReservation.AddRange(
                             new MTReservation() { ResId = 1, ResDate = DateTime.Now, Personname = "CSHARP", NoofPersons = 2, RtableId = 4 }
                         //new MTReservation() { ResId = 2, ResDate = DateTime.Now, Personname = "CSHARP", NoofPersons = 2, RtableId = 4 },
                         //new MTReservation() { ResId = 3, ResDate = DateTime.Now, Personname = "CSHARP", NoofPersons = 2, RtableId = 4 },
                         //new MTReservation() { ResId = , ResDate = DateTime.Now, Personname = "CSHARP", NoofPersons = 2, RtableId = 4 }
                         );

                        context.MRAvailableTables.AddRange(
                            new MRAvailableTables() { RtableId = 1, Capacity = 1, Statusoftable = 1 },
                            new MRAvailableTables() { RtableId = 2, Capacity = 2, Statusoftable = 1 },
                             new MRAvailableTables() { RtableId = 3, Capacity = 3, Statusoftable = 1 },
                            new MRAvailableTables() { RtableId = 4, Capacity = 4, Statusoftable = 1 },
                             new MRAvailableTables() { RtableId = 5, Capacity = 5, Statusoftable = 1 }

                        );
                

                context.SaveChanges();


            }

            _databaseInitialized = true;


        }


        //[Fact]
        //public void SaveReservation()
        //{

        //    ResetaurantResContext _context = new ResetaurantResContext(dbContextOptions);
        //    //DBiintialization obj = new DBiintialization();
        //    //obj.Seed(context);
        //    var controller = new MTReservationsController(_context);

        //    MTReservation mTReservation = new MTReservation
        //    {
        //        NoofPersons = 12,
        //        ResDate = Convert.ToDateTime("2021-11-22"),
        //        Personname = "lava",

        //    };
        //    // Act on Test  
        //    var response = controller.PostMTReservation(mTReservation).Result;
        //    Assert.NotNull(response);



        //}
        public void Dispose() => Connection.Dispose();
    }
   
}


