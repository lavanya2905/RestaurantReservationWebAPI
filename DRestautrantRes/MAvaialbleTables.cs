using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace DRestaurantReservation
{
    public  class MAvaialbleTables
    {
        public MAvaialbleTables()
        {
            TTableReservation = new HashSet<TTableReservation>();
        }

        [Key]
        public int TableId { get; set; }
        public int TCapacity { get; set; }
        public int TActive { get; set; }

        public virtual ICollection<TTableReservation> TTableReservation { get;set;}
    }
}
