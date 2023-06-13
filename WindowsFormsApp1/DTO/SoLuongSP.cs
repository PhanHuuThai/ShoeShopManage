using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class SoLuongSP
    {
        [Key,Required]
        public int ID { get; set; }
        
        public int SoLuong { get; set; }
        public int Size { get; set; }
        [Required]
        public string MSP { get; set; }
        [ForeignKey("MSP")]
        public virtual SanPham SanPham { get; set; }
    }
}
