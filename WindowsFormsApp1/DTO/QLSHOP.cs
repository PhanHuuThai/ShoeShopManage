using System;
using System.Data.Entity;
using System.Linq;
using WindowsFormsApp1.DTO;
namespace WindowsFormsApp1.DTO
{
    public class QLSHOP : DbContext
    {
        // Your context has been configured to use a 'QLSHOP' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WindowsFormsApp1.QLSHOP' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'QLSHOP' 
        // connection string in the application configuration file.
        public QLSHOP()
            : base("name=QLSHOP")
        {
            Database.SetInitializer<QLSHOP>(new CreateDB());
            
        }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<DoanhThu> DoanhThuNams { get; set; }
        public virtual DbSet<NhanVien> Nhanviens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<HoaDon> Hoadons { get; set; }
        public virtual DbSet<MaGiamGia> MaGiamGias { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<SoLuongSP> SoLuongSPs { get; set; }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<HoaDon>().HasOptional<NhanVien>(e => e.NhanVien).WithMany(d => d.HoaDonss).HasForeignKey(e => e.MaNV).WillCascadeOnDelete(true);    }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}