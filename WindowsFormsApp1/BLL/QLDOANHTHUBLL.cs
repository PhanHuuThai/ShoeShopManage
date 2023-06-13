using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.BLL
{
    internal class QLDOANHTHUBLL
    {
        QLSHOP db = new QLSHOP();
        private static QLDOANHTHUBLL _instance;
        public static QLDOANHTHUBLL instance
        {
            get
            {
                if (_instance == null)
                    _instance = new QLDOANHTHUBLL();
                return _instance;
            }
            private set { }
        }
        public void AddDoanhThu(int ngay, int thang, int nam, DoanhThu s)
        {
            if (db.DoanhThuNams.Where(p => p.NgayThang.Day == ngay && p.NgayThang.Month == thang && p.NgayThang.Year == nam).FirstOrDefault() == null)
            {
                db.DoanhThuNams.Add(s);
                db.SaveChanges();
            }
            else
            {
                var l1 = db.DoanhThuNams.Where(p => p.NgayThang.Day == ngay && p.NgayThang.Month == thang && p.NgayThang.Year == nam).ToList().FirstOrDefault();
                l1.Tongtien = l1.Tongtien + s.Tongtien;
                db.SaveChanges();
            }
        }
        public int GetDoanhThuTrongNgay(int ngay, int thang, int nam)
        {
            if (db.DoanhThuNams.Where(p => p.NgayThang.Day == ngay && p.NgayThang.Month == thang && p.NgayThang.Year == nam).FirstOrDefault() == null)
                return 0;
            else return db.DoanhThuNams.Where(p => p.NgayThang.Day == ngay && p.NgayThang.Month == thang && p.NgayThang.Year == nam).ToList().FirstOrDefault().Tongtien;
            return 0;
        }
        public double GetDoanhThuThang(int tuan, int thang, int nam)
        {
            double x = 0;
            if (tuan == 1)
            {
                foreach (DoanhThu i in db.DoanhThuNams.Where(p => p.NgayThang.Day <= 7 && p.NgayThang.Month == thang && p.NgayThang.Year == nam).ToList())
                {
                    x += i.Tongtien;
                }
            }
            if (tuan == 2)
            {
                foreach (DoanhThu i in db.DoanhThuNams.Where(p => p.NgayThang.Day <= 14 && p.NgayThang.Day > 7 && p.NgayThang.Month == thang && p.NgayThang.Year == nam).ToList())
                {
                    x += i.Tongtien;
                }
            }
            if (tuan == 3)
            {
                foreach (DoanhThu i in db.DoanhThuNams.Where(p => p.NgayThang.Day <= 21 && p.NgayThang.Day > 14 && p.NgayThang.Month == thang && p.NgayThang.Year == nam).ToList())
                {
                    x += i.Tongtien;
                }
            }
            if (tuan == 4)
            {
                foreach (DoanhThu i in db.DoanhThuNams.Where(p => p.NgayThang.Day <= 28 && p.NgayThang.Day > 21 && p.NgayThang.Month == thang && p.NgayThang.Year == nam).ToList())
                {
                    x += i.Tongtien;
                }
            }
            return x;
        }
        public double GetDoanhThuNam(int quy, int nam)
        {
            double x = 0;
            if (quy == 1)
                foreach (DoanhThu i in db.DoanhThuNams.Where(p => p.NgayThang.Month >= 1 && p.NgayThang.Month < 4 && p.NgayThang.Year == nam).ToList())
                {
                    x += i.Tongtien;
                }
            if (quy == 2)
                foreach (DoanhThu i in db.DoanhThuNams.Where(p => p.NgayThang.Month >= 4 && p.NgayThang.Month < 7 && p.NgayThang.Year == nam).ToList())
                {
                    x += i.Tongtien;
                }
            if (quy == 3)
                foreach (DoanhThu i in db.DoanhThuNams.Where(p => p.NgayThang.Month >= 7 && p.NgayThang.Month < 10 && p.NgayThang.Year == nam).ToList())
                {
                    x += i.Tongtien;
                }
            if (quy == 4)
                foreach (DoanhThu i in db.DoanhThuNams.Where(p => p.NgayThang.Month >= 10 && p.NgayThang.Month < 13 && p.NgayThang.Year == nam).ToList())
                {
                    x += i.Tongtien;
                }

            return x;
        }
        public bool checkday(List<string> x, int y)
        {
            for (int i = 0; i < x.Count; i++)
            {
                if (x[i] == y.ToString()) return false;
            }
            return true;
        }
        public List<string> GetNgay(string thang, string nam)
        {
            List<string> x = new List<string>();
            if (thang == "All" && nam == "All")
            {
                for (int i = 0; i < 32; i++)
                {
                    x.Add(i.ToString());
                }
            }
            else if (thang != "All" && nam == "All")
            {
                foreach (HoaDon i in db.Hoadons.Where(p => p.NgayThang.Month.ToString() == thang).ToList())
                {
                    if (checkday(x, i.NgayThang.Day))
                        x.Add(i.NgayThang.Day.ToString());
                }
            }
            else if (nam != "All" && thang == "")
            {
                foreach (HoaDon i in db.Hoadons.Where(p => p.NgayThang.Year.ToString() == nam).ToList())
                {
                    if (checkday(x, i.NgayThang.Day))
                        x.Add(i.NgayThang.Day.ToString());
                }
            }
            else if (nam != "All" && thang != "All")
            {
                foreach (HoaDon i in db.Hoadons.Where(p => p.NgayThang.Month.ToString() == thang && p.NgayThang.Year.ToString() == nam).ToList())
                {
                    if (checkday(x, i.NgayThang.Day))
                        x.Add(i.NgayThang.Day.ToString());
                }
            }
            return x;
        }

        public bool Checkthang(List<string> x, int thang)
        {
            for (int i = 0; i < x.Count; i++)
            {
                if (x[i] == thang.ToString()) return false;
            }
            return true;
        }
        public List<string> GetThang(string nam)
        {
            List<string> x = new List<string>();
            if (nam != "All")
            {
                foreach (HoaDon i in db.Hoadons.Where(p => p.NgayThang.Year == Convert.ToInt32(nam)).ToList())
                {
                    if (Checkthang(x, i.NgayThang.Month))
                        x.Add(i.NgayThang.Month.ToString());
                }
            }
            else
            {
                for (int i = 0; i < 13; i++)
                    x.Add(i.ToString());
            }
            return x;
        }
        public List<string> GetNam()
        {
            List<string> x = new List<string>();
            foreach (HoaDon i in db.Hoadons.Select(p => p).ToList())
            {
                if (Checkthang(x, i.NgayThang.Year))
                    x.Add(i.NgayThang.Year.ToString());
            }
            return x;
        }
    }
}
