using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class MaGiamGia
    {
        [Key]
        public int ID { get; set; }
        public string TenMGG { get; set; }
        public int phantram { get; set;  }

    }
}
