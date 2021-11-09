using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRestautrantRes;
using Microsoft.EntityFrameworkCore;


namespace BRestaurantRes.Data
{
   public class RESERVContext : DbContext

    {
        public RESERVContext(DbContextOptions<RESERVContext> options)
            : base(options)
    {
    }

    public DbSet<MTReservation> MTReservation { get; set; }

    public DbSet<MRAvailableTables> MRAvailableTables { get; set; }
}
}
