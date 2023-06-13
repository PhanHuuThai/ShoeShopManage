using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.BLL
{
    internal class QLHDBLL
    {
        QLSHOP db = new QLSHOP();
        private static QLHDBLL _instance;
        public static QLHDBLL instance
        {
            get
            {
                if (_instance == null)
                    _instance = new QLHDBLL();
                return _instance;
            }
            private set { }
        }
        public DateTime GetDayTimeFrom()
        {
            return db.Hoadons.OrderBy(p => p.NgayThang).FirstOrDefault().NgayThang;
        }
        public List<HoaDon> GetListHDbyDay(DateTime fr , DateTime en)
        {
            
                return db.Hoadons.Where(p => p.NgayThang>=fr && p.NgayThang<=en).ToList();
            

        }
        public void AddHoaDon(HoaDon s)
        {
            db.Hoadons.Add(s);
            db.SaveChanges();
        }
        public void AddChitiethoadon(ChiTietHoaDon s)
        {
            db.ChiTietHoaDons.Add(s);
            db.SaveChanges();
        }
        public List<HoaDon> GetListHD()
        {
            return db.Hoadons.Select(p => p).ToList();
        }
        public bool CheckSL(string MS, int si)
        {
            if (db.SoLuongSPs.Where(p => p.MSP == MS && p.Size == si).FirstOrDefault() != null)
                return true;
            return false;
        }
        public void AddSLSP(SoLuongSP s)
        {
            if (CheckSL(s.MSP, s.Size) == false)
            {
                db.SoLuongSPs.Add(s);
            }
            else
            {
                var l1 = db.SoLuongSPs.Where(p => p.MSP == s.MSP && p.Size == s.Size).FirstOrDefault();
                l1.SoLuong = s.SoLuong;

            }
            db.SaveChanges();
        }
        public int GetGiaThanhByMaSP(string MA)
        {
            return Convert.ToInt32(db.SanPhams.Where(p => p.MSP == MA).ToList().FirstOrDefault().GiaSP);
        }
        public int GetphantranbyMGG(string mg)
        {
            if (db.MaGiamGias.Where(p => p.TenMGG == mg).FirstOrDefault() == null)
                return 0;
            else
                return db.MaGiamGias.Where(p => p.TenMGG == mg).ToList().FirstOrDefault().phantram;
        }
        public void AddMGG(MaGiamGia x)
        {
            db.MaGiamGias.Add(x);
            db.SaveChanges();
        }
        public void DelMGG(string MG)
        {
            db.MaGiamGias.Remove(db.MaGiamGias.Find(db.MaGiamGias.Where(p => p.TenMGG == MG).FirstOrDefault().ID));
        }
        public void DelHD(string MHD)
        {
            db.Hoadons.Remove(db.Hoadons.Find(MHD));
            db.SaveChanges();
        }
        public int GetMaHDLast()
        {
            List<HoaDon> data = QLHDBLL.instance.sortMaHD();
            if (QLHDBLL.instance.sortMaHD().Count == 0)
                return 1;
            else return (Convert.ToInt32(data.Last().MaHD) + 1);
            //return 1;
        }
        public List<HoaDon> sortMaHD()
        {
            List<HoaDon> data = new List<HoaDon>();
            data = QLHDBLL.instance.GetListHD();
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = i + 1; j < data.Count; j++)
                {
                    HoaDon s;
                    if (Convert.ToInt32(data[i].MaHD) > Convert.ToInt32(data[j].MaHD))
                    {
                        s = data[i];
                        data[i] = data[j];
                        data[j] = s;
                    }
                }
            }
            return data;
        }

        public List<HoaDon> SearchHD(string s)
        {
            List<HoaDon> data = new List<HoaDon>();
            data = db.Hoadons.Where(p => p.MaHD.Contains(s) || p.MaNV.Contains(s)).Select(p => p).ToList();
            return data;
        }

        public List<Hoadonview> GetHoaDonView(List<HoaDon> a)
        {
            List<Hoadonview> data = new List<Hoadonview>();
            foreach (HoaDon i in a)
            {
                data.Add(new Hoadonview
                {
                    MaHD = i.MaHD,
                    NgayThang = i.NgayThang,
                    TongSL = i.TongSL,
                    TongTien = i.TongTien,
                    TenNV = QLNHANVIENBLL.instance.GetNVByMaNV(i.MaNV).Name,
                });
            }
            return data;
        }

        public List<ChiTietHoaDonView> GetChiTietHoaDonViews(List<ChiTietHoaDon> a)
        {
            List<ChiTietHoaDonView> data = new List<ChiTietHoaDonView>();
            foreach (ChiTietHoaDon i in a)
                data.Add(new ChiTietHoaDonView
                {
                    NameSP = QLSANPHAMBLL.instance.GetSPbyMaSP(i.MSP).TenSP,
                    Size = i.Size,
                    SoLuong = i.SoLuong,
                    GiaThanh = QLHDBLL.instance.GetGiaThanhByMaSP(i.MSP),
                    TongTien = QLHDBLL.instance.GetGiaThanhByMaSP(i.MSP) * i.SoLuong,

                });

            return data;
        }
        public List<HoaDon> GetListHoaDon(string ngay, string thang, string nam)
        {
            int n = 0, t = 0, na = 0;
            if (ngay == "All") n = 1;
            if (thang == "All") t = 1;
            if (nam == "All") na = 1;
            if (na == 1 && n == 1 && t == 1)
                return db.Hoadons.Select(p => p).ToList();
            else if (na == 1 && t == 1)
                return db.Hoadons.Where(p => p.NgayThang.Day.ToString() == (ngay)).ToList();
            else if (na == 1 && n == 1)
                return db.Hoadons.Where(p => p.NgayThang.Month.ToString() == (thang)).ToList();
            else if (t == 1 && n == 1)
                return db.Hoadons.Where(p => p.NgayThang.Year.ToString() == (nam)).ToList();
            else if (t == 1)
                return db.Hoadons.Where(p => p.NgayThang.Year.ToString() == (nam) && p.NgayThang.Day.ToString() == (ngay)).ToList();
            else if (na == 1)
                return db.Hoadons.Where(p => p.NgayThang.Month.ToString() == (thang) && p.NgayThang.Day.ToString() == (ngay)).ToList();
            else if (n == 1)
                return db.Hoadons.Where(p => p.NgayThang.Year.ToString() == (nam) && p.NgayThang.Month.ToString() == (thang)).ToList();
            else if (n == 0 && na == 0 && t == 0)
                return db.Hoadons.Where(p => p.NgayThang.Month.ToString() == (thang) && p.NgayThang.Year.ToString() == (nam) && p.NgayThang.Day.ToString() == (ngay)).ToList();
            return null;
        }
        public HoaDon GetHDbyMAHD(string MHD)
        {
            return db.Hoadons.Where(p => p.MaHD == MHD).ToList().FirstOrDefault();
        }

        public List<ChiTietHoaDon> GetListChiTietHoaDon()
        {
            return db.ChiTietHoaDons.ToList();
        }
        public List<ChiTietHoaDon> searchhd(string s)
        {
            List<ChiTietHoaDon> data = new List<ChiTietHoaDon>();
            data = db.ChiTietHoaDons.Where(p => p.MaHD == s).ToList();
            return data;
        }
        public List<HoaDon> SortHD(string type)
        {
            List<HoaDon> data = QLHDBLL.instance.GetListHD();
            switch (type)
            {
                case "Ma hoa don":
                    {
                        data = QLHDBLL.instance.sortMaHD();
                        break;
                    }
                case "Tong so luong":
                    {
                        data = db.Hoadons.OrderBy(p => p.TongSL).ToList();
                        break;
                    }
                case "Tong tien":
                    {
                        data = db.Hoadons.OrderBy(p => p.TongTien).ToList();
                        break;
                    }
            }
            return data;
        }
    }
}