using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantResTest
{
    public class MyEntity
    {
        public string Name { get; set; }
    }

    // Provides a repository for MyEntity objects.
    public class MyEntityRepository
    {
        private Func<MyDbContext> createContext;

        // Initializes a new instance of the MyEntityRepository class using
        // the specified DbContext factory method.
        public MyEntityRepository(Func<MyDbContext> createContext)
        {
            this.createContext = createContext;
        }

        // Gets all the entities with the specified name.
        public IEnumerable<MyEntity> GetMyEntities(string name)
        {
            using (var context = this.createContext())
            {
                return context.MyEntities
                    .Where(myEntity => myEntity.Name == name)
                    .ToArray();
            }
        }
    }

    public class MyDbContext : DbContext
    {
        public virtual DbSet<MyEntity> MyEntities { get; set; }
    }
}
