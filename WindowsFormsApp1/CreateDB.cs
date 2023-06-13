using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1
{
    internal class CreateDB : CreateDatabaseIfNotExists<QLSHOP>
    {
        
        protected override void Seed(QLSHOP context)
        {
            context.Accounts.AddRange(new Account[]
            {
                new Account{ID=1,TenDangNhap="NV01",MatKhau="123",IsOwner=false},
                new Account{ID=2,TenDangNhap="NV02",MatKhau="123",IsOwner=false},
                new Account{ID=3,TenDangNhap="Admin",MatKhau="123",IsOwner=true},
            });

            context.Nhanviens.AddRange(new NhanVien[]
            {
                new NhanVien{MaNV = "NV01",Name = "Hai Duoi",Gmail = "123@gmail.com",SDT = 123,Gender = false,LuongCB = 2000 ,DiaChi = "5 Ton Duc Thang", NgaySinh = "21/02/2002"},
                new NhanVien{MaNV = "NV02",Name = "Vu Phu",Gmail = "456@gmail.com",SDT = 456,Gender = true,LuongCB = 3000,DiaChi = "7 Nguyen Luong Bang", NgaySinh = "1/05/2002"},
            });

        }
        
    }
}