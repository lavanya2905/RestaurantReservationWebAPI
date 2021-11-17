using System.ComponentModel.DataAnnotations;
namespace DRestaurantReservation
{
    public sealed class MAvaialbleTables
    {
        [Key]
        public int TableId{ get; set; }
        public int TCapacity{ get; set; }
        public int TActive{ get; set; }
    }
}
