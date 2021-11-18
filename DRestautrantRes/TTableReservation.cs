using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DRestaurantReservation
{
    public  class TTableReservation
     {
        public TTableReservation()
        {
           
        }
        [Key]
        [DatabaseGenerat‌ed(System.ComponentM‌​odel.DataAnnotations‌​.Schema.DatabaseGeneratedOp‌​tion.Identity)]
        public long ID { get; set; }
       
        public string Name { get; set; } = string.Empty;
        public DateTime ResDate { get; set; }
        public int NumberOfPersons { get; set; }
        
        public int TableId { get; set; }
        [ForeignKey("TableId")]
        public virtual MAvaialbleTables TableInfo { get; set; }
    }

}
