using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.BLL
{
    internal class QLACCOUNTQLL
    {
        QLSHOP db = new QLSHOP();
        private static QLACCOUNTQLL _instance;
        public static QLACCOUNTQLL instance
        {
            get
            {
                if (_instance == null)
                    _instance = new QLACCOUNTQLL();
                return _instance;
            }
            private set { }
        }
        public List<Account> GetListacc()
        {
            return db.Accounts.ToList();
        }
        public int getaccount(string TK, string MK)
        {
            if (db.Accounts.Where(p => p.TenDangNhap == TK && p.MatKhau == MK).Select(p => p).ToList().FirstOrDefault() == null)
                return 0;

            else if (db.Accounts.Where(p => p.TenDangNhap == TK && p.MatKhau == MK).Select(p => p).ToList().FirstOrDefault().IsOwner)
                return 2;

            return 1;
        }

        public string forgotpassword(string account, string gmail)
        {

            if (db.Nhanviens.Where(p => p.MaNV == account && p.Gmail == gmail).Select(p => p).ToList().FirstOrDefault() == null)
                return "0";
            else

            {
                return db.Accounts.Where(p => p.TenDangNhap == account).Select(p => p.MatKhau).ToList().FirstOrDefault();

            }

        }

        public int FindPassword(string account, string password, string newpassword, string conformpassword)
        {
            if (db.Accounts.Where(p => p.TenDangNhap == account && p.MatKhau == password).Select(p => p).ToList().FirstOrDefault() != null)
            {
                if (newpassword == conformpassword)
                {
                    return 0;
                }
                else
                    return 1;
            }
            return 2;
        }


        public void changepassword(string account, string newpassword)
        {

            var l1 = db.Accounts.Where(p => p.TenDangNhap == account).FirstOrDefault();
            l1.MatKhau = newpassword;
            db.SaveChanges();
        }
    }
}
