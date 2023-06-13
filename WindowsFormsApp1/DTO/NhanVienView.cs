using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class NhanVienView
    {
        public string MaNV { get; set; }
        public string Name { get; set; }
        public string Gmail { get; set; }
        public int SDT { get; set; }
        public int LuongCB { get; set; }
        public bool Gender { get; set; }
        public string DiaChi { get; set; }
        public string NgaySinh { get; set; }
        public double SoGioLamViec { get; set; }
        public double Luong { get; set; }
    }
}
