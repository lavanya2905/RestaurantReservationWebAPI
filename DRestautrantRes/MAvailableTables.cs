using System.ComponentModel.DataAnnotations;
namespace DRestaurantReservation
{
    public sealed class MAvailableTables
    {
        [Key]
        public int TableId { get; set; }
        public int Capacity { get; set; }
        public int Active { get; set; }
    }
}
