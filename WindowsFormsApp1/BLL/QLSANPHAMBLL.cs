using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.BLL
{

    public class QLSANPHAMBLL
    {
        QLSHOP db = new QLSHOP();
        private static QLSANPHAMBLL _instance;
        public static QLSANPHAMBLL instance
        {
            get
            {
                if (_instance == null)

                    _instance = new QLSANPHAMBLL();

                return _instance;
            }
            private set { }
        }

        public bool Check(string MS)
        {
            if (db.SanPhams.Where(p => p.MSP == MS).FirstOrDefault() != null)

                return true;
            return false;
        }
        public bool CheckSL(string MS, int si)
        {
            if (db.SoLuongSPs.Where(p => p.MSP == MS && p.Size == si).FirstOrDefault() != null)
                return true;
            return false;
        }
        public void AddUpdateSP(SanPham s)
        {
            if (Check(s.MSP) == false)
            {
                db.SanPhams.Add(s);
            }
            else
            {
                var l1 = db.SanPhams.Where(p => p.MSP == s.MSP).FirstOrDefault();
                l1.MSP = s.MSP;
                l1.Link = s.Link;
                l1.TongSLSP = s.TongSLSP;
                l1.GiaSP = s.GiaSP;
                l1.TenSP = s.TenSP;
            }
            db.SaveChanges();
        }
        public void UpdateTongSLSPbyMaSP(string Ma, int SLtru)
        {
            var l1 = db.SanPhams.Where(p => p.MSP == Ma).FirstOrDefault();
            l1.TongSLSP = l1.TongSLSP - SLtru;
            db.SaveChanges();
        }
        public int GetSLSPByMSPandSize(string MSP, int size)
        {

            if (db.SoLuongSPs.Where(p => p.MSP == MSP && p.Size == size).FirstOrDefault() == null)
                return 0;
            else return db.SoLuongSPs.Where(p => p.MSP == MSP && p.Size == size).ToList().FirstOrDefault().SoLuong;
            return 0;

        }
        public int GetSLbyMaSPandSize(string MS, int sz)
        {
            return db.SoLuongSPs.Where(p => p.MSP == MS && p.Size == sz).ToList().FirstOrDefault().SoLuong;
        }
        public SanPham GetSPbyMaSP(string MS)
        {
            return db.SanPhams.Where(p => p.MSP == MS).ToList().FirstOrDefault();
        }
        public string GetMaSPbyTenSP(string MS)
        {
            return db.SanPhams.Where(p => p.TenSP == MS).ToList().FirstOrDefault().MSP;
        }
        public List<SanPham> GetListSP()
        {
            return db.SanPhams.ToList();
        }

        public List<SanPhamView> GetSPView(List<SanPham> a)
        {
            List<SanPhamView> data = new List<SanPhamView>();
            foreach (SanPham i in a)
            {
                data.Add(new SanPhamView
                {
                    MSP = i.MSP,
                    TongSLSP = i.TongSLSP,
                    TenSP = i.TenSP,
                    GiaSP = i.GiaSP
                });
            }
            return data;
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

        public List<SanPham> SortSP(string type)
        {

            List<SanPham> data = QLSANPHAMBLL.instance.GetListSP();
            switch (type)
            {
                case "Ma San Pham":
                    {
                        data = QLSANPHAMBLL.instance.sortMasp();
                        break;
                    }
                case "So luong san pham":
                    {
                        data = db.SanPhams.OrderBy(p => p.TongSLSP).ToList();
                        break;
                    }
                case "Gia san pham":
                    {
                        data = QLSANPHAMBLL.instance.sortGiasp();
                        break; 
                    }
            }
            return data; 
        }

        public List<SanPham> sortGiasp()
        {
            List<SanPham> data = new List<SanPham>();
            data = QLSANPHAMBLL.instance.GetListSP();
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = i + 1; j < data.Count; j++)
                {
                    SanPham s;
                    if (Convert.ToInt32(data[i].GiaSP) > Convert.ToInt32(data[j].GiaSP))
                    {
                        s = data[i];
                        data[i] = data[j];
                        data[j] = s;
                    }
                }
            }
            return data;
        }

        public List<SanPham> sortMasp()
        {
            List<SanPham> data = QLSANPHAMBLL.instance.GetListSP(); ;
            //data = QLSHOPBLL.instance.GetListSP();
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = i + 1; j < data.Count; j++)
                {
                    SanPham s;
                    if (Convert.ToInt32(data[i].MSP.Substring(2)) > Convert.ToInt32(data[j].MSP.Substring(2)))
                    {
                        s = data[i];
                        data[i] = data[j];
                        data[j] = s;
                    }
                }
            }
            return data;
        }


        public List<SanPham> SearchSP(string s)
        {
            List<SanPham> data = new List<SanPham>();
            data = db.SanPhams.Where(p => p.MSP.Contains(s) || p.TenSP.Contains(s)).Select(p => p).ToList();
            return data;
        }
        public int GetMaSPLast()
        {
            List<SanPham> data = QLSANPHAMBLL.instance.sortMasp();
            if (QLSANPHAMBLL.instance.sortMasp().Count == 0)
                return 1;
            else return (Convert.ToInt32(data.Last().MSP.Substring(2)) + 1);
            //return 1;
        }

        public string setMaSP()
        {
            string s = "";
            if (GetMaSPLast() < 10)
                s = "SP0" + GetMaSPLast().ToString();
            else
                s = "SP" + GetMaSPLast().ToString();
            return s;
        }
        public void DellSP(string MS)
        {
            var l1 = db.SoLuongSPs.Where(p => p.MSP == MS && p.Size == 36).FirstOrDefault();
            l1.SoLuong = 0;
            var l2 = db.SoLuongSPs.Where(p => p.MSP == MS && p.Size == 37).FirstOrDefault();
            l2.SoLuong = 0;
            var l3 = db.SoLuongSPs.Where(p => p.MSP == MS && p.Size == 38).FirstOrDefault();
            l3.SoLuong = 0;
            var l4 = db.SoLuongSPs.Where(p => p.MSP == MS && p.Size == 39).FirstOrDefault();
            l4.SoLuong = 0;
            var l5 = db.SoLuongSPs.Where(p => p.MSP == MS && p.Size == 40).FirstOrDefault();
            l5.SoLuong = 0;
            var l6 = db.SoLuongSPs.Where(p => p.MSP == MS && p.Size == 41).FirstOrDefault();
            l6.SoLuong = 0;
            var l7 = db.SoLuongSPs.Where(p => p.MSP == MS && p.Size == 42).FirstOrDefault();
            l7.SoLuong = 0;
            var l8 = db.SoLuongSPs.Where(p => p.MSP == MS && p.Size == 43).FirstOrDefault();
            l8.SoLuong = 0;
            var l9 = db.SanPhams.Where(p => p.MSP == MS).FirstOrDefault();
            l9.TongSLSP = 0;

        }
       
    }
}
