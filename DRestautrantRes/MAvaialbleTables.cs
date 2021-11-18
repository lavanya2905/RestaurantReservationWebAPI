using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace DRestaurantReservation
{
    public class MAvaialbleTables
    {
       
        [Key]
        public int TableId { get; set; }
        public int TCapacity { get; set; }
        public int TActive { get; set; }

        
    }
}
