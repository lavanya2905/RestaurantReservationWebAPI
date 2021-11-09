using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DRestautrantRes
{
  public class MTReservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        public int ResId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}"), Required]

       
        public DateTime ResDate { get; set; }

        [MinLength(2), Required]
        public string Personname { get; set; }

        [Range(1, 12)]
        public int NoofPersons { get; set; }

        [ReadOnly(true)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [DefaultValue(1)]
        public int RtableId { get; set; }


        //public int Statusofrestable { get; set; }

    }
}
