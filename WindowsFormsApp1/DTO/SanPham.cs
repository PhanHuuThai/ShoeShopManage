using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class SanPham
    {
        public SanPham()
        {
            ChiTietHoaDonss = new HashSet<ChiTietHoaDon>() ;
            SoLuongSPss = new HashSet<SoLuongSP>(); 
        }
        [Key,Required]
        public string MSP { get; set; }
        public int TongSLSP { get; set; }
        public string Link { get; set; }
        public string TenSP { get; set; }   
        public string GiaSP { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDonss { get; set; }
        public virtual ICollection<SoLuongSP> SoLuongSPss { get; set;  }
    }
}
