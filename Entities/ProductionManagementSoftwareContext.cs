using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class ProductionManagementSoftwareContext : DbContext
    {
        public ProductionManagementSoftwareContext()
        {
        }

        public ProductionManagementSoftwareContext(DbContextOptions<ProductionManagementSoftwareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Bangdinhmuc> Bangdinhmuc { get; set; }
        public virtual DbSet<Chitietgiaidoansanxuathoanghoathanhpham> Chitietgiaidoansanxuathoanghoathanhpham { get; set; }
        public virtual DbSet<Chitietnganhangkh> Chitietnganhangkh { get; set; }
        public virtual DbSet<Chitietnganhangncc> Chitietnganhangncc { get; set; }
        public virtual DbSet<Donhangsanxuat> Donhangsanxuat { get; set; }
        public virtual DbSet<Giaidoansanxuat> Giaidoansanxuat { get; set; }
        public virtual DbSet<Hanghoathanhpham> Hanghoathanhpham { get; set; }
        public virtual DbSet<Hangsanxuat> Hangsanxuat { get; set; }
        public virtual DbSet<Hinhthucthanhtoan> Hinhthucthanhtoan { get; set; }
        public virtual DbSet<Khachhang> Khachhang { get; set; }
        public virtual DbSet<Loainhanvien> Loainhanvien { get; set; }
        public virtual DbSet<Nganhang> Nganhang { get; set; }
        public virtual DbSet<Nhacungcap> Nhacungcap { get; set; }
        public virtual DbSet<Nhanvien> Nhanvien { get; set; }
        public virtual DbSet<Nhomvatlieu> Nhomvatlieu { get; set; }
        public virtual DbSet<Noidungdondathangsanxuat> Noidungdondathangsanxuat { get; set; }
        public virtual DbSet<Noidungphieunhap> Noidungphieunhap { get; set; }
        public virtual DbSet<Noidungthunodondathangkh> Noidungthunodondathangkh { get; set; }
        public virtual DbSet<Noidungthunokh> Noidungthunokh { get; set; }
        public virtual DbSet<Noidungtranoncc> Noidungtranoncc { get; set; }
        public virtual DbSet<Phieubanhang> Phieubanhang { get; set; }
        public virtual DbSet<Phieunhapkho> Phieunhapkho { get; set; }
        public virtual DbSet<Phieuthunokh> Phieuthunokh { get; set; }
        public virtual DbSet<Phieutranoncc> Phieutranoncc { get; set; }
        public virtual DbSet<Tosanxuat> Tosanxuat { get; set; }
        public virtual DbSet<Tosanxuathanghoathanhpham> Tosanxuathanghoathanhpham { get; set; }
        public virtual DbSet<Trangthaidonhang> Trangthaidonhang { get; set; }
        public virtual DbSet<Vaitro> Vaitro { get; set; }
        public virtual DbSet<Vatlieu> Vatlieu { get; set; }
        public virtual DbSet<Vatlieusanxuatbandau> Vatlieusanxuatbandau { get; set; }
        public virtual DbSet<Vatlieusanxuatthuc> Vatlieusanxuatthuc { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ProductionManagementSoftware;Persist Security Info=True;User ID=sa;Password=sa");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Idaccount)
                    .HasName("PK__ACCOUNT__F3DEE7EF7D69B549");

                entity.ToTable("ACCOUNT");

                entity.Property(e => e.Idaccount).HasColumnName("IDACCOUNT");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Mk)
                    .HasColumnName("MK")
                    .HasMaxLength(255);

                entity.Property(e => e.Tk)
                    .HasColumnName("TK")
                    .HasMaxLength(255);

                entity.Property(e => e.Vaitroidvt).HasColumnName("VAITROIDVT");

                entity.HasOne(d => d.VaitroidvtNavigation)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.Vaitroidvt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKACCOUNT591048");
            });

            modelBuilder.Entity<Bangdinhmuc>(entity =>
            {
                entity.HasKey(e => e.Idbdm)
                    .HasName("PK__BANGDINH__93673A7E8692E352");

                entity.ToTable("BANGDINHMUC");

                entity.Property(e => e.Idbdm).HasColumnName("IDBDM");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(255);

                entity.Property(e => e.Mabdm)
                    .HasColumnName("MABDM")
                    .HasMaxLength(255);

                entity.Property(e => e.Tenbdm)
                    .HasColumnName("TENBDM")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Chitietgiaidoansanxuathoanghoathanhpham>(entity =>
            {
                entity.HasKey(e => new { e.Idctdgsxhhtp, e.Giaidoansanxuatidgdsx, e.Hanghoathanhphamidhhtp })
                    .HasName("PK__CHITIETG__E4ACA6AC9C1E9173");

                entity.ToTable("CHITIETGIAIDOANSANXUATHOANGHOATHANHPHAM");

                entity.Property(e => e.Idctdgsxhhtp)
                    .HasColumnName("IDCTDGSXHHTP")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Giaidoansanxuatidgdsx).HasColumnName("GIAIDOANSANXUATIDGDSX");

                entity.Property(e => e.Hanghoathanhphamidhhtp).HasColumnName("HANGHOATHANHPHAMIDHHTP");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(255);

                entity.HasOne(d => d.GiaidoansanxuatidgdsxNavigation)
                    .WithMany(p => p.Chitietgiaidoansanxuathoanghoathanhpham)
                    .HasForeignKey(d => d.Giaidoansanxuatidgdsx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCHITIETGIA43412");

                entity.HasOne(d => d.HanghoathanhphamidhhtpNavigation)
                    .WithMany(p => p.Chitietgiaidoansanxuathoanghoathanhpham)
                    .HasForeignKey(d => d.Hanghoathanhphamidhhtp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCHITIETGIA637244");
            });

            modelBuilder.Entity<Chitietnganhangkh>(entity =>
            {
                entity.HasKey(e => new { e.Idctnhkh, e.Nganhangidnh, e.Khachhangidkh })
                    .HasName("PK__CHITIETN__A1A81CBA20758FC5");

                entity.ToTable("CHITIETNGANHANGKH");

                entity.Property(e => e.Idctnhkh)
                    .HasColumnName("IDCTNHKH")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nganhangidnh).HasColumnName("NGANHANGIDNH");

                entity.Property(e => e.Khachhangidkh).HasColumnName("KHACHHANGIDKH");

                entity.Property(e => e.Stk)
                    .HasColumnName("STK")
                    .HasMaxLength(255);

                entity.HasOne(d => d.KhachhangidkhNavigation)
                    .WithMany(p => p.Chitietnganhangkh)
                    .HasForeignKey(d => d.Khachhangidkh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCHITIETNGA80199");

                entity.HasOne(d => d.NganhangidnhNavigation)
                    .WithMany(p => p.Chitietnganhangkh)
                    .HasForeignKey(d => d.Nganhangidnh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCHITIETNGA338890");
            });

            modelBuilder.Entity<Chitietnganhangncc>(entity =>
            {
                entity.HasKey(e => new { e.Idctnhncc, e.Nhacungcapidncc, e.Nganhangidnh })
                    .HasName("PK__CHITIETN__9E5D199E1D7BF013");

                entity.ToTable("CHITIETNGANHANGNCC");

                entity.Property(e => e.Idctnhncc)
                    .HasColumnName("IDCTNHNCC")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nhacungcapidncc).HasColumnName("NHACUNGCAPIDNCC");

                entity.Property(e => e.Nganhangidnh).HasColumnName("NGANHANGIDNH");

                entity.Property(e => e.Stk)
                    .HasColumnName("STK")
                    .HasMaxLength(255);

                entity.HasOne(d => d.NganhangidnhNavigation)
                    .WithMany(p => p.Chitietnganhangncc)
                    .HasForeignKey(d => d.Nganhangidnh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCHITIETNGA129997");

                entity.HasOne(d => d.NhacungcapidnccNavigation)
                    .WithMany(p => p.Chitietnganhangncc)
                    .HasForeignKey(d => d.Nhacungcapidncc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCHITIETNGA150525");
            });

            modelBuilder.Entity<Donhangsanxuat>(entity =>
            {
                entity.HasKey(e => e.Iddhsx)
                    .HasName("PK__DONHANGS__4AB92D992575BFD0");

                entity.ToTable("DONHANGSANXUAT");

                entity.Property(e => e.Iddhsx).HasColumnName("IDDHSX");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(255);

                entity.Property(e => e.Khachhangidkh).HasColumnName("KHACHHANGIDKH");

                entity.Property(e => e.Madhsx)
                    .HasColumnName("MADHSX")
                    .HasMaxLength(255);

                entity.Property(e => e.Ngaydat)
                    .HasColumnName("NGAYDAT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ngaygiao)
                    .HasColumnName("NGAYGIAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Trangthaidonhangidttdh).HasColumnName("TRANGTHAIDONHANGIDTTDH");

                entity.HasOne(d => d.KhachhangidkhNavigation)
                    .WithMany(p => p.Donhangsanxuat)
                    .HasForeignKey(d => d.Khachhangidkh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDONHANGSAN165526");

                entity.HasOne(d => d.TrangthaidonhangidttdhNavigation)
                    .WithMany(p => p.Donhangsanxuat)
                    .HasForeignKey(d => d.Trangthaidonhangidttdh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDONHANGSAN516678");
            });

            modelBuilder.Entity<Giaidoansanxuat>(entity =>
            {
                entity.HasKey(e => e.Idgdsx)
                    .HasName("PK__GIAIDOAN__D495060447D3E1F4");

                entity.ToTable("GIAIDOANSANXUAT");

                entity.Property(e => e.Idgdsx).HasColumnName("IDGDSX");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Donvingaycong)
                    .HasColumnName("DONVINGAYCONG")
                    .HasMaxLength(255);

                entity.Property(e => e.Magdsx)
                    .HasColumnName("MAGDSX")
                    .HasMaxLength(255);

                entity.Property(e => e.Tengdsx)
                    .HasColumnName("TENGDSX")
                    .HasMaxLength(255);

                entity.Property(e => e.Trinhtusanxuat)
                    .HasColumnName("TRINHTUSANXUAT")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Hanghoathanhpham>(entity =>
            {
                entity.HasKey(e => e.Idhhtp)
                    .HasName("PK__HANGHOAT__FBBBAB4232D094F6");

                entity.ToTable("HANGHOATHANHPHAM");

                entity.Property(e => e.Idhhtp).HasColumnName("IDHHTP");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Bangdinhmucidbdm).HasColumnName("BANGDINHMUCIDBDM");

                entity.Property(e => e.Hinhanh)
                    .HasColumnName("HINHANH")
                    .HasMaxLength(255);

                entity.Property(e => e.Mahhtp)
                    .HasColumnName("MAHHTP")
                    .HasMaxLength(255);

                entity.Property(e => e.Mota)
                    .HasColumnName("MOTA")
                    .HasMaxLength(255);

                entity.Property(e => e.Tenhhtp)
                    .HasColumnName("TENHHTP")
                    .HasMaxLength(255);

                entity.HasOne(d => d.BangdinhmucidbdmNavigation)
                    .WithMany(p => p.Hanghoathanhpham)
                    .HasForeignKey(d => d.Bangdinhmucidbdm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKHANGHOATHA232779");
            });

            modelBuilder.Entity<Hangsanxuat>(entity =>
            {
                entity.HasKey(e => e.Idhsx)
                    .HasName("PK__HANGSANX__A60A17A3AF10403C");

                entity.ToTable("HANGSANXUAT");

                entity.Property(e => e.Idhsx).HasColumnName("IDHSX");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.Mahsx)
                    .HasColumnName("MAHSX")
                    .HasMaxLength(255);

                entity.Property(e => e.Tenhsx)
                    .HasColumnName("TENHSX")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Hinhthucthanhtoan>(entity =>
            {
                entity.HasKey(e => e.Idhttt)
                    .HasName("PK__HINHTHUC__9DCEA6E39EFA424B");

                entity.ToTable("HINHTHUCTHANHTOAN");

                entity.Property(e => e.Idhttt).HasColumnName("IDHTTT");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Mahttt)
                    .HasColumnName("MAHTTT")
                    .HasMaxLength(255);

                entity.Property(e => e.Tenhttt)
                    .HasColumnName("TENHTTT")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Idkh)
                    .HasName("PK__KHACHHAN__B87DC1A702D75E73");

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.Idkh).HasColumnName("IDKH");

                entity.Property(e => e.Accountidaccount).HasColumnName("ACCOUNTIDACCOUNT");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Diachi)
                    .HasColumnName("DIACHI")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(255);

                entity.Property(e => e.Gioitinh)
                    .HasColumnName("GIOITINH")
                    .HasMaxLength(255);

                entity.Property(e => e.Makh)
                    .HasColumnName("MAKH")
                    .HasMaxLength(255);

                entity.Property(e => e.Masothue)
                    .HasColumnName("MASOTHUE")
                    .HasMaxLength(255);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.Nvidsale).HasColumnName("NVIDSale");

                entity.Property(e => e.Sdt)
                    .HasColumnName("SDT")
                    .HasMaxLength(255);

                entity.Property(e => e.Tenkh)
                    .HasColumnName("TENKH")
                    .HasMaxLength(255);

                entity.HasOne(d => d.AccountidaccountNavigation)
                    .WithMany(p => p.Khachhang)
                    .HasForeignKey(d => d.Accountidaccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKKHACHHANG476625");
            });

            modelBuilder.Entity<Loainhanvien>(entity =>
            {
                entity.HasKey(e => e.Idlnv)
                    .HasName("PK__LOAINHAN__95D70E5091166D1A");

                entity.ToTable("LOAINHANVIEN");

                entity.Property(e => e.Idlnv).HasColumnName("IDLNV");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(255);

                entity.Property(e => e.Malnv)
                    .HasColumnName("MALNV")
                    .HasMaxLength(255);

                entity.Property(e => e.Tenlnv)
                    .HasColumnName("TENLNV")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Nganhang>(entity =>
            {
                entity.HasKey(e => e.Idnh)
                    .HasName("PK__NGANHANG__B87DC9448C3F58FB");

                entity.ToTable("NGANHANG");

                entity.Property(e => e.Idnh).HasColumnName("IDNH");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Diachi)
                    .HasColumnName("DIACHI")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(255);

                entity.Property(e => e.Hinhthucthanhtoanidhttt).HasColumnName("HINHTHUCTHANHTOANIDHTTT");

                entity.Property(e => e.Masothue)
                    .HasColumnName("MASOTHUE")
                    .HasMaxLength(255);

                entity.Property(e => e.Tennh)
                    .HasColumnName("TENNH")
                    .HasMaxLength(255);

                entity.HasOne(d => d.HinhthucthanhtoanidhtttNavigation)
                    .WithMany(p => p.Nganhang)
                    .HasForeignKey(d => d.Hinhthucthanhtoanidhttt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNGANHANG786571");
            });

            modelBuilder.Entity<Nhacungcap>(entity =>
            {
                entity.HasKey(e => e.Idncc)
                    .HasName("PK__NHACUNGC__945E47056089684B");

                entity.ToTable("NHACUNGCAP");

                entity.Property(e => e.Idncc).HasColumnName("IDNCC");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Diachi)
                    .HasColumnName("DIACHI")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(255);

                entity.Property(e => e.Mancc)
                    .HasColumnName("MANCC")
                    .HasMaxLength(255);

                entity.Property(e => e.Masothue)
                    .HasColumnName("MASOTHUE")
                    .HasMaxLength(255);

                entity.Property(e => e.Sdt)
                    .HasColumnName("SDT")
                    .HasMaxLength(255);

                entity.Property(e => e.Tenncc)
                    .HasColumnName("TENNCC")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.Idnv)
                    .HasName("PK__NHANVIEN__B87DC9B2648AB7A6");

                entity.ToTable("NHANVIEN");

                entity.Property(e => e.Idnv).HasColumnName("IDNV");

                entity.Property(e => e.Accountidaccount).HasColumnName("ACCOUNTIDACCOUNT");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Diachi)
                    .HasColumnName("DIACHI")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(255);

                entity.Property(e => e.Gioitinh)
                    .HasColumnName("GIOITINH")
                    .HasMaxLength(255);

                entity.Property(e => e.Loainhanvienidlnv).HasColumnName("LOAINHANVIENIDLNV");

                entity.Property(e => e.Manv)
                    .HasColumnName("MANV")
                    .HasMaxLength(255);

                entity.Property(e => e.Sdt)
                    .HasColumnName("SDT")
                    .HasMaxLength(255);

                entity.Property(e => e.Tennv)
                    .HasColumnName("TENNV")
                    .HasMaxLength(255);

                entity.Property(e => e.Tosxid).HasColumnName("TOSXID");

                entity.HasOne(d => d.AccountidaccountNavigation)
                    .WithMany(p => p.Nhanvien)
                    .HasForeignKey(d => d.Accountidaccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNHANVIEN150316");

                entity.HasOne(d => d.LoainhanvienidlnvNavigation)
                    .WithMany(p => p.Nhanvien)
                    .HasForeignKey(d => d.Loainhanvienidlnv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNHANVIEN287288");
            });

            modelBuilder.Entity<Nhomvatlieu>(entity =>
            {
                entity.HasKey(e => e.Idnvl)
                    .HasName("PK__NHOMVATL__945B88AAB23F858D");

                entity.ToTable("NHOMVATLIEU");

                entity.Property(e => e.Idnvl).HasColumnName("IDNVL");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.Loaivl)
                    .HasColumnName("LOAIVL")
                    .HasMaxLength(255);

                entity.Property(e => e.Manvl)
                    .HasColumnName("MANVL")
                    .HasMaxLength(255);

                entity.Property(e => e.Tennvl)
                    .HasColumnName("TENNVL")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Noidungdondathangsanxuat>(entity =>
            {
                entity.HasKey(e => new { e.Idndddhsx, e.Donhangsanxuatiddhsx, e.Hanghoathanhphamidhhtp })
                    .HasName("PK__NOIDUNGD__818F06E186A910FA");

                entity.ToTable("NOIDUNGDONDATHANGSANXUAT");

                entity.Property(e => e.Idndddhsx)
                    .HasColumnName("IDNDDDHSX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Donhangsanxuatiddhsx).HasColumnName("DONHANGSANXUATIDDHSX");

                entity.Property(e => e.Hanghoathanhphamidhhtp).HasColumnName("HANGHOATHANHPHAMIDHHTP");

                entity.Property(e => e.Dongia)
                    .HasColumnName("DONGIA")
                    .HasMaxLength(255);

                entity.Property(e => e.Soluong)
                    .HasColumnName("SOLUONG")
                    .HasMaxLength(255);

                entity.HasOne(d => d.DonhangsanxuatiddhsxNavigation)
                    .WithMany(p => p.Noidungdondathangsanxuat)
                    .HasForeignKey(d => d.Donhangsanxuatiddhsx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGDON204590");

                entity.HasOne(d => d.HanghoathanhphamidhhtpNavigation)
                    .WithMany(p => p.Noidungdondathangsanxuat)
                    .HasForeignKey(d => d.Hanghoathanhphamidhhtp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGDON454288");
            });

            modelBuilder.Entity<Noidungphieunhap>(entity =>
            {
                entity.HasKey(e => new { e.Idpnk, e.Vatlieuidvl, e.Phieunhapkhoidpnk })
                    .HasName("PK__NOIDUNGP__DB2EB267F3625A15");

                entity.ToTable("NOIDUNGPHIEUNHAP");

                entity.Property(e => e.Idpnk)
                    .HasColumnName("IDPNK")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Vatlieuidvl).HasColumnName("VATLIEUIDVL");

                entity.Property(e => e.Phieunhapkhoidpnk).HasColumnName("PHIEUNHAPKHOIDPNK");

                entity.Property(e => e.Dongia)
                    .HasColumnName("DONGIA")
                    .HasMaxLength(255);

                entity.Property(e => e.Soluong)
                    .HasColumnName("SOLUONG")
                    .HasMaxLength(255);

                entity.HasOne(d => d.PhieunhapkhoidpnkNavigation)
                    .WithMany(p => p.Noidungphieunhap)
                    .HasForeignKey(d => d.Phieunhapkhoidpnk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGPHI323304");

                entity.HasOne(d => d.VatlieuidvlNavigation)
                    .WithMany(p => p.Noidungphieunhap)
                    .HasForeignKey(d => d.Vatlieuidvl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGPHI793723");
            });

            modelBuilder.Entity<Noidungthunodondathangkh>(entity =>
            {
                entity.HasKey(e => new { e.Idndtnddhkh, e.Phieuthunokhidptnkh, e.Donhangsanxuatiddhsx })
                    .HasName("PK__NOIDUNGT__4943AF0C65F9D7C0");

                entity.ToTable("NOIDUNGTHUNODONDATHANGKH");

                entity.Property(e => e.Idndtnddhkh)
                    .HasColumnName("IDNDTNDDHKH")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Phieuthunokhidptnkh).HasColumnName("PHIEUTHUNOKHIDPTNKH");

                entity.Property(e => e.Donhangsanxuatiddhsx).HasColumnName("DONHANGSANXUATIDDHSX");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(255);

                entity.Property(e => e.Ngaythuno)
                    .HasColumnName("NGAYTHUNO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sotien)
                    .HasColumnName("SOTIEN")
                    .HasMaxLength(255);

                entity.HasOne(d => d.DonhangsanxuatiddhsxNavigation)
                    .WithMany(p => p.Noidungthunodondathangkh)
                    .HasForeignKey(d => d.Donhangsanxuatiddhsx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGTHU691610");

                entity.HasOne(d => d.PhieuthunokhidptnkhNavigation)
                    .WithMany(p => p.Noidungthunodondathangkh)
                    .HasForeignKey(d => d.Phieuthunokhidptnkh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGTHU172404");
            });

            modelBuilder.Entity<Noidungthunokh>(entity =>
            {
                entity.HasKey(e => new { e.Idndtnkh, e.Phieuthunokhidptnkh, e.Phieubanhangidpbh })
                    .HasName("PK__NOIDUNGT__63952D1A99E083C6");

                entity.ToTable("NOIDUNGTHUNOKH");

                entity.Property(e => e.Idndtnkh)
                    .HasColumnName("IDNDTNKH")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Phieuthunokhidptnkh).HasColumnName("PHIEUTHUNOKHIDPTNKH");

                entity.Property(e => e.Phieubanhangidpbh).HasColumnName("PHIEUBANHANGIDPBH");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(255);

                entity.Property(e => e.Ngaythuno)
                    .HasColumnName("NGAYTHUNO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sotien)
                    .HasColumnName("SOTIEN")
                    .HasMaxLength(255);

                entity.HasOne(d => d.PhieubanhangidpbhNavigation)
                    .WithMany(p => p.Noidungthunokh)
                    .HasForeignKey(d => d.Phieubanhangidpbh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGTHU247172");

                entity.HasOne(d => d.PhieuthunokhidptnkhNavigation)
                    .WithMany(p => p.Noidungthunokh)
                    .HasForeignKey(d => d.Phieuthunokhidptnkh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGTHU662665");
            });

            modelBuilder.Entity<Noidungtranoncc>(entity =>
            {
                entity.HasKey(e => new { e.Idndtnncc, e.Phieunhapkhoidpnk, e.Phieutranonccidptnncc })
                    .HasName("PK__NOIDUNGT__0488D42D816B723F");

                entity.ToTable("NOIDUNGTRANONCC");

                entity.Property(e => e.Idndtnncc)
                    .HasColumnName("IDNDTNNCC")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Phieunhapkhoidpnk).HasColumnName("PHIEUNHAPKHOIDPNK");

                entity.Property(e => e.Phieutranonccidptnncc).HasColumnName("PHIEUTRANONCCIDPTNNCC");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(255);

                entity.Property(e => e.Ngaytrano)
                    .HasColumnName("NGAYTRANO")
                    .HasMaxLength(255);

                entity.Property(e => e.Sotien)
                    .HasColumnName("SOTIEN")
                    .HasMaxLength(255);

                entity.HasOne(d => d.PhieunhapkhoidpnkNavigation)
                    .WithMany(p => p.Noidungtranoncc)
                    .HasForeignKey(d => d.Phieunhapkhoidpnk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGTRA625746");

                entity.HasOne(d => d.PhieutranonccidptnnccNavigation)
                    .WithMany(p => p.Noidungtranoncc)
                    .HasForeignKey(d => d.Phieutranonccidptnncc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGTRA161405");
            });

            modelBuilder.Entity<Phieubanhang>(entity =>
            {
                entity.HasKey(e => e.Idpbh)
                    .HasName("PK__PHIEUBAN__98FEB3C4D7C19796");

                entity.ToTable("PHIEUBANHANG");

                entity.Property(e => e.Idpbh).HasColumnName("IDPBH");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(255);

                entity.Property(e => e.Khachhangidkh).HasColumnName("KHACHHANGIDKH");

                entity.Property(e => e.Ngayhd)
                    .HasColumnName("NGAYHD")
                    .HasMaxLength(255);

                entity.Property(e => e.Ngaylap)
                    .HasColumnName("NGAYLAP")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nhanvienidnv).HasColumnName("NHANVIENIDNV");

                entity.Property(e => e.Sohd)
                    .HasColumnName("SOHD")
                    .HasMaxLength(255);

                entity.Property(e => e.Sophieu)
                    .HasColumnName("SOPHIEU")
                    .HasMaxLength(255);

                entity.HasOne(d => d.KhachhangidkhNavigation)
                    .WithMany(p => p.Phieubanhang)
                    .HasForeignKey(d => d.Khachhangidkh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPHIEUBANHA285688");

                entity.HasOne(d => d.NhanvienidnvNavigation)
                    .WithMany(p => p.Phieubanhang)
                    .HasForeignKey(d => d.Nhanvienidnv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPHIEUBANHA809679");
            });

            modelBuilder.Entity<Phieunhapkho>(entity =>
            {
                entity.HasKey(e => e.Idpnk)
                    .HasName("PK__PHIEUNHA__98FEDC482DAFC8E5");

                entity.ToTable("PHIEUNHAPKHO");

                entity.Property(e => e.Idpnk).HasColumnName("IDPNK");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(255);

                entity.Property(e => e.Ngayhd)
                    .HasColumnName("NGAYHD")
                    .HasMaxLength(255);

                entity.Property(e => e.Ngaynhap)
                    .HasColumnName("NGAYNHAP")
                    .HasMaxLength(255);

                entity.Property(e => e.Nhanvienidnv).HasColumnName("NHANVIENIDNV");

                entity.Property(e => e.Sohd)
                    .HasColumnName("SOHD")
                    .HasMaxLength(255);

                entity.Property(e => e.Sophieu)
                    .HasColumnName("SOPHIEU")
                    .HasMaxLength(255);

                entity.HasOne(d => d.NhanvienidnvNavigation)
                    .WithMany(p => p.Phieunhapkho)
                    .HasForeignKey(d => d.Nhanvienidnv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPHIEUNHAPK404038");
            });

            modelBuilder.Entity<Phieuthunokh>(entity =>
            {
                entity.HasKey(e => e.Idptnkh)
                    .HasName("PK__PHIEUTHU__02AF4104FA7E5D00");

                entity.ToTable("PHIEUTHUNOKH");

                entity.Property(e => e.Idptnkh).HasColumnName("IDPTNKH");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(255);

                entity.Property(e => e.Hinhthucthanhtoanidhttt).HasColumnName("HINHTHUCTHANHTOANIDHTTT");

                entity.Property(e => e.Nhanvienidnv).HasColumnName("NHANVIENIDNV");

                entity.HasOne(d => d.HinhthucthanhtoanidhtttNavigation)
                    .WithMany(p => p.Phieuthunokh)
                    .HasForeignKey(d => d.Hinhthucthanhtoanidhttt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPHIEUTHUNO424815");

                entity.HasOne(d => d.NhanvienidnvNavigation)
                    .WithMany(p => p.Phieuthunokh)
                    .HasForeignKey(d => d.Nhanvienidnv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPHIEUTHUNO66568");
            });

            modelBuilder.Entity<Phieutranoncc>(entity =>
            {
                entity.HasKey(e => e.Idptnncc)
                    .HasName("PK__PHIEUTRA__B57294B746741E7E");

                entity.ToTable("PHIEUTRANONCC");

                entity.Property(e => e.Idptnncc).HasColumnName("IDPTNNCC");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(255);

                entity.Property(e => e.Hinhthucthanhtoanidhttt).HasColumnName("HINHTHUCTHANHTOANIDHTTT");

                entity.Property(e => e.Nhanvienidnv).HasColumnName("NHANVIENIDNV");

                entity.HasOne(d => d.HinhthucthanhtoanidhtttNavigation)
                    .WithMany(p => p.Phieutranoncc)
                    .HasForeignKey(d => d.Hinhthucthanhtoanidhttt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPHIEUTRANO390415");

                entity.HasOne(d => d.NhanvienidnvNavigation)
                    .WithMany(p => p.Phieutranoncc)
                    .HasForeignKey(d => d.Nhanvienidnv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPHIEUTRANO89792");
            });

            modelBuilder.Entity<Tosanxuat>(entity =>
            {
                entity.HasKey(e => e.Idtsx)
                    .HasName("PK__TOSANXUA__A70204AD118F573F");

                entity.ToTable("TOSANXUAT");

                entity.Property(e => e.Idtsx).HasColumnName("IDTSX");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(255);

                entity.Property(e => e.Giaidoansanxuatidgdsx).HasColumnName("GIAIDOANSANXUATIDGDSX");

                entity.Property(e => e.Matsx)
                    .HasColumnName("MATSX")
                    .HasMaxLength(255);

                entity.Property(e => e.Tentsx)
                    .HasColumnName("TENTSX")
                    .HasMaxLength(255);

                entity.HasOne(d => d.GiaidoansanxuatidgdsxNavigation)
                    .WithMany(p => p.Tosanxuat)
                    .HasForeignKey(d => d.Giaidoansanxuatidgdsx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTOSANXUAT338232");
            });

            modelBuilder.Entity<Tosanxuathanghoathanhpham>(entity =>
            {
                entity.HasKey(e => new { e.Idtsxhhtp, e.Tosanxuatidtsx, e.Hanghoathanhphamidhhtp })
                    .HasName("PK__TOSANXUA__CCFEFCBA249DF71F");

                entity.ToTable("TOSANXUATHANGHOATHANHPHAM");

                entity.Property(e => e.Idtsxhhtp)
                    .HasColumnName("IDTSXHHTP")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Tosanxuatidtsx).HasColumnName("TOSANXUATIDTSX");

                entity.Property(e => e.Hanghoathanhphamidhhtp).HasColumnName("HANGHOATHANHPHAMIDHHTP");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(255);

                entity.Property(e => e.Ngaybd)
                    .HasColumnName("NGAYBD")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ngaykt)
                    .HasColumnName("NGAYKT")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.HanghoathanhphamidhhtpNavigation)
                    .WithMany(p => p.Tosanxuathanghoathanhpham)
                    .HasForeignKey(d => d.Hanghoathanhphamidhhtp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTOSANXUATH427864");

                entity.HasOne(d => d.TosanxuatidtsxNavigation)
                    .WithMany(p => p.Tosanxuathanghoathanhpham)
                    .HasForeignKey(d => d.Tosanxuatidtsx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTOSANXUATH27904");
            });

            modelBuilder.Entity<Trangthaidonhang>(entity =>
            {
                entity.HasKey(e => e.Idttdh)
                    .HasName("PK__TRANGTHA__BD6AFA049368F32F");

                entity.ToTable("TRANGTHAIDONHANG");

                entity.Property(e => e.Idttdh).HasColumnName("IDTTDH");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Mattdh)
                    .HasColumnName("MATTDH")
                    .HasMaxLength(255);

                entity.Property(e => e.Tenttdh)
                    .HasColumnName("TENTTDH")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Vaitro>(entity =>
            {
                entity.HasKey(e => e.Idvt)
                    .HasName("PK__VAITRO__B87C0ABAAB2DBCF7");

                entity.ToTable("VAITRO");

                entity.Property(e => e.Idvt).HasColumnName("IDVT");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(255);

                entity.Property(e => e.Mavt)
                    .HasColumnName("MAVT")
                    .HasMaxLength(255);

                entity.Property(e => e.Tenvt)
                    .HasColumnName("TENVT")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Vatlieu>(entity =>
            {
                entity.HasKey(e => e.Idvl)
                    .HasName("PK__VATLIEU__B87C0A423544A525");

                entity.ToTable("VATLIEU");

                entity.Property(e => e.Idvl).HasColumnName("IDVL");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Donvitinh)
                    .HasColumnName("DONVITINH")
                    .HasMaxLength(255);

                entity.Property(e => e.Giaban)
                    .HasColumnName("GIABAN")
                    .HasMaxLength(255);

                entity.Property(e => e.Hangsanxuatidhsx).HasColumnName("HANGSANXUATIDHSX");

                entity.Property(e => e.Mavl)
                    .HasColumnName("MAVL")
                    .HasMaxLength(255);

                entity.Property(e => e.Nhacungcapidncc).HasColumnName("NHACUNGCAPIDNCC");

                entity.Property(e => e.Nhomvatlieuidnvl).HasColumnName("NHOMVATLIEUIDNVL");

                entity.Property(e => e.Quycach)
                    .HasColumnName("QUYCACH")
                    .HasMaxLength(255);

                entity.Property(e => e.Tenvl)
                    .HasColumnName("TENVL")
                    .HasMaxLength(255);

                entity.HasOne(d => d.HangsanxuatidhsxNavigation)
                    .WithMany(p => p.Vatlieu)
                    .HasForeignKey(d => d.Hangsanxuatidhsx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKVATLIEU883549");

                entity.HasOne(d => d.NhacungcapidnccNavigation)
                    .WithMany(p => p.Vatlieu)
                    .HasForeignKey(d => d.Nhacungcapidncc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKVATLIEU696857");

                entity.HasOne(d => d.NhomvatlieuidnvlNavigation)
                    .WithMany(p => p.Vatlieu)
                    .HasForeignKey(d => d.Nhomvatlieuidnvl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKVATLIEU30392");
            });

            modelBuilder.Entity<Vatlieusanxuatbandau>(entity =>
            {
                entity.HasKey(e => new { e.Idvlsxbd, e.Vatlieuidvl, e.Bangdinhmucidbdm })
                    .HasName("PK__VATLIEUS__498E6E1208C83380");

                entity.ToTable("VATLIEUSANXUATBANDAU");

                entity.Property(e => e.Idvlsxbd)
                    .HasColumnName("IDVLSXBD")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Vatlieuidvl).HasColumnName("VATLIEUIDVL");

                entity.Property(e => e.Bangdinhmucidbdm).HasColumnName("BANGDINHMUCIDBDM");

                entity.Property(e => e.Dongiadm)
                    .HasColumnName("DONGIADM")
                    .HasMaxLength(255);

                entity.Property(e => e.Donvitinh)
                    .HasColumnName("DONVITINH")
                    .HasMaxLength(255);

                entity.Property(e => e.Soluong)
                    .HasColumnName("SOLUONG")
                    .HasMaxLength(255);

                entity.HasOne(d => d.BangdinhmucidbdmNavigation)
                    .WithMany(p => p.Vatlieusanxuatbandau)
                    .HasForeignKey(d => d.Bangdinhmucidbdm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKVATLIEUSAN565867");

                entity.HasOne(d => d.VatlieuidvlNavigation)
                    .WithMany(p => p.Vatlieusanxuatbandau)
                    .HasForeignKey(d => d.Vatlieuidvl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKVATLIEUSAN102344");
            });

            modelBuilder.Entity<Vatlieusanxuatthuc>(entity =>
            {
                entity.HasKey(e => new { e.Idvlt, e.Vatlieuidvl, e.Hanghoathanhphamidhhtp })
                    .HasName("PK__VATLIEUS__A4CDEAB0F1E4FEC1");

                entity.ToTable("VATLIEUSANXUATTHUC");

                entity.Property(e => e.Idvlt)
                    .HasColumnName("IDVLT")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Vatlieuidvl).HasColumnName("VATLIEUIDVL");

                entity.Property(e => e.Hanghoathanhphamidhhtp).HasColumnName("HANGHOATHANHPHAMIDHHTP");

                entity.Property(e => e.Donvitinh)
                    .HasColumnName("DONVITINH")
                    .HasMaxLength(255);

                entity.Property(e => e.Soluong)
                    .HasColumnName("SOLUONG")
                    .HasMaxLength(255);

                entity.HasOne(d => d.HanghoathanhphamidhhtpNavigation)
                    .WithMany(p => p.Vatlieusanxuatthuc)
                    .HasForeignKey(d => d.Hanghoathanhphamidhhtp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKVATLIEUSAN356642");

                entity.HasOne(d => d.VatlieuidvlNavigation)
                    .WithMany(p => p.Vatlieusanxuatthuc)
                    .HasForeignKey(d => d.Vatlieuidvl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKVATLIEUSAN352474");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
