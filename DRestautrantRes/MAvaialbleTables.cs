using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DRestaurantReservation
{
    public sealed class MAvaialbleTables
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TableId{ get; set; }
        public int TCapacity{ get; set; }
        public int TActive{ get; set; }
    }
}
