using Microsoft.EntityFrameworkCore;
using System;
namespace DRestaurantReservation
{
    [Keyless]
     public class TTableReservation
     {        
        public string Name { get; set; } = string.Empty;
        public DateTime ResDate { get; set; }
        public int NumberOfPersons { get; set; }
        public int TableId { get; set; }
    }

}
