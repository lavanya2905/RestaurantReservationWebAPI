using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DRestautrantRes
{
   public class MRAvailableTables
    {
        [Key]
        public int RtableId { get; set; }
        public int Capacity { get; set; }

        public int Statusoftable { get; set; }
    }
}
