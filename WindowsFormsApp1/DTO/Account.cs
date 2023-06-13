using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class Account
    {
        [Key] 
        public int ID { get; set; }
        public string TenDangNhap { get; set; } 
        public string MatKhau { get; set;  }
        public bool IsOwner { get; set; }
    }
}
