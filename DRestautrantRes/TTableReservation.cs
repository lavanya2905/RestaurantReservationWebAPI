using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DRestaurantReservation
{
    public  class TTableReservation
     {
       
        [Key]
        [DatabaseGenerat‌ed(DatabaseGeneratedOp‌​tion.Identity)]
        public long ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime ResDate { get; set; }
        public int NumberOfPersons { get; set; }
        public int TableId { get; set; }
      

    }
}
