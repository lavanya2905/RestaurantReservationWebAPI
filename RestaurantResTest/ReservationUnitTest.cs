using BRestaurantRes;
using BRestaurantRes.Data;
using DRestautrantRes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResetaurantRes.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RestaurantResTest
{
 public  class ReservationUnitTest
    {
        private readonly IRestableResvation _restableResvation;
        public static DbContextOptions<ResetaurantResContext> dbContextOptions;
        public ReservationUnitTest()
        {
            dbContextOptions = new DbContextOptionsBuilder<ResetaurantResContext>()
                  .UseSqlServer("Data Source=LAPTOP-LR3RK1IO\\SQLEXPRESS;Initial Catalog=restaurant;Integrated Security=True;Pooling=False").Options;

        }
        [Fact]
        public void GetallReservations()
        {
            ResetaurantResContext _context = new ResetaurantResContext(dbContextOptions);
            //DBiintialization obj = new DBiintialization();
            //obj.Seed(context);
            var controller = new MTReservationsController(_context);
            MTReservation mTReservation = new MTReservation();
            // Act on Test  
            var response = controller.GetMTReservation().Result;

            Assert.IsType<ActionResult<IEnumerable<MTReservation>>>(response);
            Assert.NotNull(response);
           
           


        }

        [Fact]
        public void GetallReservationById()
        {
            int id = 2;
            ResetaurantResContext _context = new ResetaurantResContext(dbContextOptions);
            //DBiintialization obj = new DBiintialization();
            //obj.Seed(context);
            var controller = new MTReservationsController(_context);
            
            MTReservation mTReservation = new MTReservation
            {
                NoofPersons = 3,
                ResDate = Convert.ToDateTime("2021-11-09"),
                Personname = "String",
                RtableId = 3,
                ResId = 2
            };
            // Act on Test  
            var response = controller.GetMTReservationId(id).Result;
            Assert.NotNull(response);
            Assert.IsType<ActionResult<MTReservation>>(response);
            Assert.NotNull(response);
            //Assert.True(response.Value.Equals(mTReservation));

        }

        [Fact]
        public void SaveReservation()
        {
         
            ResetaurantResContext _context = new ResetaurantResContext(dbContextOptions);
            //DBiintialization obj = new DBiintialization();
            //obj.Seed(context);
            var controller = new MTReservationsController(_context);

            MTReservation mTReservation = new MTReservation
            {
                NoofPersons = 12,
                ResDate = Convert.ToDateTime("2021-11-22"),
                Personname = "lava",
               
            };
            // Act on Test  
            var response = controller.PostMTReservation(mTReservation).Result;
            Assert.NotNull(response);
            
          

        }
    }
}
