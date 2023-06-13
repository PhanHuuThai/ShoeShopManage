using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class DoanhThu
    {
        [Key]
        public int ID { get; set; }
        public DateTime NgayThang { get; set; }
        public int Tongtien { get; set;  }

    }
}
