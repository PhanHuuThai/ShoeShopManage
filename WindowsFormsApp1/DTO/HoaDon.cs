using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class HoaDon
    {
        public HoaDon()
        {
            ChiTietHoaDonss = new HashSet<ChiTietHoaDon>(); 
        }
        [Key,Required]
        public string MaHD { get; set; }
        public DateTime NgayThang { get; set; }
        public int TongSL { get; set; }
        public string MGG { get; set; }
        public int TongTien { get; set; }
        [Required]
        public string MaNV { get; set; }
        [ForeignKey("MaNV")]
        public virtual NhanVien NhanVien { get; set;  }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDonss { get; set; }

    }
}
