using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DRestautrantRes;

namespace ResetaurantRes.Data
{
    public class ResetaurantResContext : DbContext
    {
        public ResetaurantResContext (DbContextOptions<ResetaurantResContext> options)
            : base(options)
        {
        }

        public DbSet<DRestautrantRes.MRAvailableTables> MRAvailableTables { get; set; }

        public DbSet<DRestautrantRes.MTReservation> MTReservation { get; set; }
    }
}
