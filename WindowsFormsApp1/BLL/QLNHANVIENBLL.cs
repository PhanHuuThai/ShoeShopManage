using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.BLL
{
    internal class QLNHANVIENBLL
    {
        QLSHOP db = new QLSHOP();
        private static QLNHANVIENBLL _instance;
        public static QLNHANVIENBLL instance
        {
            get
            {
                if (_instance == null)
                    _instance = new QLNHANVIENBLL();
                return _instance;
            }
            private set { }
        }
        public List<NhanVien> GetListNhanVien()
        {
            return db.Nhanviens.ToList();
        }

        public bool checkNV(string MNV)
        {
            if (db.Nhanviens.Where(p => p.MaNV == MNV).ToList().FirstOrDefault() != null)
                return true;
            return false;
        }

        public List<NhanVienView> GetNhanvienViews(List<NhanVien> a)
        {
            List<NhanVienView> nv = new List<NhanVienView>();
            foreach (NhanVien v in a)
            {
                if(v.Luong!=-1)
                nv.Add(new NhanVienView
                {
                    MaNV = v.MaNV,
                    Name = v.Name,
                    Gmail = v.Gmail,
                    SDT = v.SDT,
                    LuongCB = v.LuongCB,
                    Gender = v.Gender,
                    DiaChi = v.DiaChi,
                    NgaySinh = v.NgaySinh,
                    SoGioLamViec = v.SoGioLamViec,
                    Luong = v.LuongCB * v.SoGioLamViec,
                });
            }
            return nv;
        }

        public void AddUpdateNV(NhanVien n)
        {
            if (checkNV(n.MaNV) == false)
            {
                db.Nhanviens.Add(n);
                db.Accounts.Add(new Account { TenDangNhap = n.MaNV, MatKhau = "123", IsOwner = false });

            }
            else
            {
                var l1 = db.Nhanviens.Where(p => p.MaNV == n.MaNV).FirstOrDefault();
                l1.MaNV = n.MaNV;
                l1.Name = n.Name;
                l1.Gmail = n.Gmail;
                l1.SDT = n.SDT;
                l1.LuongCB = n.LuongCB;
                l1.Gender = n.Gender;
                l1.DiaChi = n.DiaChi;
                l1.NgaySinh = n.NgaySinh;
            }

            db.SaveChanges();
        }

        public void DelNV(string MNV)
        {
            var l1 = db.Nhanviens.Where(p => p.MaNV == MNV).FirstOrDefault();
            l1.Luong = -1; 
            db.Accounts.Remove(db.Accounts.Find(db.Accounts.Where(p => p.TenDangNhap == MNV).FirstOrDefault().ID));
            db.SaveChanges();
        }


        public NhanVien GetNVByMaNV(string MNV)
        {
            return db.Nhanviens.Where(p => p.MaNV == MNV).ToList().FirstOrDefault();
        }
        public string GetMaNVByName(string NameNV)
        {
            return db.Nhanviens.Where(p => p.Name == NameNV).FirstOrDefault().MaNV;
        }



        public List<NhanVien> SortNV(string type)
        {
            List<NhanVien> data = QLNHANVIENBLL.instance.GetListNhanVien();
            switch (type)
            {
                case "Ma Nhan Vien":
                    {
                        data = QLNHANVIENBLL.instance.sortMaNV();
                        break;
                    }
                case "Ten Nhan Vien":
                    {
                        data = db.Nhanviens.OrderBy(p => p.Name).ToList();
                        break;
                    }
                case "Luong co ban":
                    {
                        data = db.Nhanviens.OrderBy(p => p.LuongCB).ToList();
                        break;
                    }
            }
            return data;
        }

        public List<NhanVien> sortMaNV()
        {
            List<NhanVien> data = new List<NhanVien>();
            data = QLNHANVIENBLL.instance.GetListNhanVien();
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = i + 1; j < data.Count; j++)
                {
                    NhanVien s;
                    if (Convert.ToInt32(data[i].MaNV.Substring(2)) > Convert.ToInt32(data[j].MaNV.Substring(2)))
                    {
                        s = data[i];
                        data[i] = data[j];
                        data[j] = s;
                    }
                }
            }
            return data;
        }

        public List<NhanVien> SeachNV(string s)
        {
            List<NhanVien> data = new List<NhanVien>();
            data = db.Nhanviens.Where(p => p.MaNV.Contains(s) || p.Name.Contains(s)).ToList();
            return data;
        }
        public void AddGio(string MaNV, double time)
        {
            var l1 = db.Nhanviens.Where(p => p.MaNV == MaNV).FirstOrDefault();
            l1.SoGioLamViec += time;
            db.SaveChanges();
        }
        public int GetMaNVLast()
        {
            List<NhanVien> data = QLNHANVIENBLL.instance.sortMaNV();
            if (QLNHANVIENBLL.instance.sortMaNV().Count == 0)
                return 1;
            else return (Convert.ToInt32(data.Last().MaNV.Substring(2)) + 1);
            return 1;
        }

        public string setMaNV()
        {
            string s = "";
            if (GetMaNVLast() < 10)
                s = "NV0" + GetMaNVLast().ToString();
            else
                s = "NV" + GetMaNVLast().ToString();
            return s;
        }



        public void resetLuong()
        {

            var l1 = db.Nhanviens.Select(p => p);
            foreach (NhanVien i in l1)
            {
                i.SoGioLamViec = 0;
            }
            db.SaveChanges();
        }
    }
}
