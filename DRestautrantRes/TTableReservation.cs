using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DRestaurantReservation
{
  public sealed class TTableReservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime ResDate { get; set; }
        public int NumberOfPersons { get; set; }
        public int TableId { get; set; }
        public int RActive { get; set; }
    }
}
