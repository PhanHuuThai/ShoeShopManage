using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class ChiTietHoaDon
    {
        [Key]
        public int ID { get; set; }
        [Required]
       
       
        public int SoLuong { get; set; }
        public int Size { get; set; }
        public string MaHD { get; set; }
        [ForeignKey("MaHD")]
        public virtual HoaDon HoaDon { get; set; }
        [Required]
        public string MSP { get; set; }
        [ForeignKey("MSP")]
        public virtual SanPham SanPham { get; set; }

    }
}
