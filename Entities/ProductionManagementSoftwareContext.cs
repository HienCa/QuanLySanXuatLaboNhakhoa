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

        public virtual DbSet<Bangdinhmuc> Bangdinhmuc { get; set; }
        public virtual DbSet<Ctgiaidoansxhhtp> Ctgiaidoansxhhtp { get; set; }
        public virtual DbSet<Ctnganhangkh> Ctnganhangkh { get; set; }
        public virtual DbSet<Ctnganhangncc> Ctnganhangncc { get; set; }
        public virtual DbSet<Cttosxhhtp> Cttosxhhtp { get; set; }
        public virtual DbSet<Dondathangsx> Dondathangsx { get; set; }
        public virtual DbSet<Giaidoansx> Giaidoansx { get; set; }
        public virtual DbSet<Hanghoathanhpham> Hanghoathanhpham { get; set; }
        public virtual DbSet<Hangsx> Hangsx { get; set; }
        public virtual DbSet<Hinhthucthanhtoan> Hinhthucthanhtoan { get; set; }
        public virtual DbSet<Khachhang> Khachhang { get; set; }
        public virtual DbSet<Nganhang> Nganhang { get; set; }
        public virtual DbSet<Nhacungcapvl> Nhacungcapvl { get; set; }
        public virtual DbSet<Nhanvien> Nhanvien { get; set; }
        public virtual DbSet<Nhomvl> Nhomvl { get; set; }
        public virtual DbSet<Noidungddhsx> Noidungddhsx { get; set; }
        public virtual DbSet<Noidungpbh> Noidungpbh { get; set; }
        public virtual DbSet<Noidungpnk> Noidungpnk { get; set; }
        public virtual DbSet<Noidungthunoddhsx> Noidungthunoddhsx { get; set; }
        public virtual DbSet<Noidungthunokh> Noidungthunokh { get; set; }
        public virtual DbSet<Noidungtranoncc> Noidungtranoncc { get; set; }
        public virtual DbSet<Nuocsx> Nuocsx { get; set; }
        public virtual DbSet<Phieubanhang> Phieubanhang { get; set; }
        public virtual DbSet<Phieunhapkho> Phieunhapkho { get; set; }
        public virtual DbSet<Phieuthunokh> Phieuthunokh { get; set; }
        public virtual DbSet<Phieutranoncc> Phieutranoncc { get; set; }
        public virtual DbSet<Tosanxuat> Tosanxuat { get; set; }
        public virtual DbSet<Vatlieu> Vatlieu { get; set; }
        public virtual DbSet<Vatlieusxbd> Vatlieusxbd { get; set; }
        public virtual DbSet<Vatlieusxtt> Vatlieusxtt { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // #warning directive
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ProductionManagementSoftware;Persist Security Info=True;User ID=sa;Password=sa");
#pragma warning restore CS1030 // #warning directive
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bangdinhmuc>(entity =>
            {
                entity.HasKey(e => e.Idbdm)
                    .HasName("PK__BANGDINH__93673A7E7A62A7AE");

                entity.ToTable("BANGDINHMUC");

                entity.Property(e => e.Idbdm).HasColumnName("IDBDM");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Mabdm)
                    .HasColumnName("MABDM")
                    .HasMaxLength(255);

                entity.Property(e => e.Tenbdm)
                    .IsRequired()
                    .HasColumnName("TENBDM")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Ctgiaidoansxhhtp>(entity =>
            {
                entity.HasKey(e => new { e.Idctgdsxhhtp, e.Idgdsx, e.Idhhtp })
                    .HasName("PK__CTGIAIDO__838BF5CB57EB2451");

                entity.ToTable("CTGIAIDOANSXHHTP");

                entity.Property(e => e.Idctgdsxhhtp)
                    .HasColumnName("IDCTGDSXHHTP")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idgdsx).HasColumnName("IDGDSX");

                entity.Property(e => e.Idhhtp).HasColumnName("IDHHTP");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.HasOne(d => d.IdgdsxNavigation)
                    .WithMany(p => p.Ctgiaidoansxhhtp)
                    .HasForeignKey(d => d.Idgdsx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCTGIAIDOAN471065");

                entity.HasOne(d => d.IdhhtpNavigation)
                    .WithMany(p => p.Ctgiaidoansxhhtp)
                    .HasForeignKey(d => d.Idhhtp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCTGIAIDOAN438681");
            });

            modelBuilder.Entity<Ctnganhangkh>(entity =>
            {
                entity.HasKey(e => new { e.Idctnhkh, e.Idkh, e.Idnh })
                    .HasName("PK__CTNGANHA__D882C9191E381615");

                entity.ToTable("CTNGANHANGKH");

                entity.Property(e => e.Idctnhkh)
                    .HasColumnName("IDCTNHKH")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idkh).HasColumnName("IDKH");

                entity.Property(e => e.Idnh).HasColumnName("IDNH");

                entity.Property(e => e.Stk)
                    .IsRequired()
                    .HasColumnName("STK")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdkhNavigation)
                    .WithMany(p => p.Ctnganhangkh)
                    .HasForeignKey(d => d.Idkh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCTNGANHANG63746");

                entity.HasOne(d => d.IdnhNavigation)
                    .WithMany(p => p.Ctnganhangkh)
                    .HasForeignKey(d => d.Idnh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCTNGANHANG333690");
            });

            modelBuilder.Entity<Ctnganhangncc>(entity =>
            {
                entity.HasKey(e => new { e.Idctnhncc, e.Idnh, e.Idncc })
                    .HasName("PK__CTNGANHA__A94E23410A497806");

                entity.ToTable("CTNGANHANGNCC");

                entity.Property(e => e.Idctnhncc)
                    .HasColumnName("IDCTNHNCC")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idnh).HasColumnName("IDNH");

                entity.Property(e => e.Idncc).HasColumnName("IDNCC");

                entity.Property(e => e.Stk).HasColumnName("STK");

                entity.HasOne(d => d.IdnccNavigation)
                    .WithMany(p => p.Ctnganhangncc)
                    .HasForeignKey(d => d.Idncc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCTNGANHANG621514");

                entity.HasOne(d => d.IdnhNavigation)
                    .WithMany(p => p.Ctnganhangncc)
                    .HasForeignKey(d => d.Idnh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCTNGANHANG844559");
            });

            modelBuilder.Entity<Cttosxhhtp>(entity =>
            {
                entity.HasKey(e => new { e.Idcttsxhhtp, e.Idtsx, e.Idhhtp })
                    .HasName("PK__CTTOSXHH__F0BD6FB756704B74");

                entity.ToTable("CTTOSXHHTP");

                entity.Property(e => e.Idcttsxhhtp)
                    .HasColumnName("IDCTTSXHHTP")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idtsx).HasColumnName("IDTSX");

                entity.Property(e => e.Idhhtp).HasColumnName("IDHHTP");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Ngaybd)
                    .HasColumnName("NGAYBD")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ngaykt)
                    .HasColumnName("NGAYKT")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdhhtpNavigation)
                    .WithMany(p => p.Cttosxhhtp)
                    .HasForeignKey(d => d.Idhhtp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCTTOSXHHTP947945");

                entity.HasOne(d => d.IdtsxNavigation)
                    .WithMany(p => p.Cttosxhhtp)
                    .HasForeignKey(d => d.Idtsx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCTTOSXHHTP797612");
            });

            modelBuilder.Entity<Dondathangsx>(entity =>
            {
                entity.HasKey(e => e.Iddhsx)
                    .HasName("PK__DONDATHA__4AB92D9982FC6385");

                entity.ToTable("DONDATHANGSX");

                entity.Property(e => e.Iddhsx).HasColumnName("IDDHSX");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Idkh).HasColumnName("IDKH");

                entity.Property(e => e.Madhsx)
                    .HasColumnName("MADHSX")
                    .HasMaxLength(255);

                entity.Property(e => e.Ngaydat)
                    .HasColumnName("NGAYDAT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ngaygiao)
                    .HasColumnName("NGAYGIAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Trangthai)
                    .IsRequired()
                    .HasColumnName("TRANGTHAI")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdkhNavigation)
                    .WithMany(p => p.Dondathangsx)
                    .HasForeignKey(d => d.Idkh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDONDATHANG676586");
            });

            modelBuilder.Entity<Giaidoansx>(entity =>
            {
                entity.HasKey(e => e.Idgdsx)
                    .HasName("PK__GIAIDOAN__D4950604FA1763BA");

                entity.ToTable("GIAIDOANSX");

                entity.Property(e => e.Idgdsx).HasColumnName("IDGDSX");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Donvingaycong).HasColumnName("DONVINGAYCONG");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Magdsx)
                    .HasColumnName("MAGDSX")
                    .HasMaxLength(255);

                entity.Property(e => e.Tengdsx)
                    .IsRequired()
                    .HasColumnName("TENGDSX")
                    .HasMaxLength(255);

                entity.Property(e => e.Trinhtusx).HasColumnName("TRINHTUSX");
            });

            modelBuilder.Entity<Hanghoathanhpham>(entity =>
            {
                entity.HasKey(e => e.Idhhtp)
                    .HasName("PK__HANGHOAT__FBBBAB42C2F27935");

                entity.ToTable("HANGHOATHANHPHAM");

                entity.Property(e => e.Idhhtp).HasColumnName("IDHHTP");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Dongiachung).HasColumnName("DONGIACHUNG");

                entity.Property(e => e.Hinhanh)
                    .HasColumnName("HINHANH")
                    .HasMaxLength(255);

                entity.Property(e => e.Idbdm).HasColumnName("IDBDM");

                entity.Property(e => e.Mahhtp)
                    .HasColumnName("MAHHTP")
                    .HasMaxLength(255);

                entity.Property(e => e.Mota)
                    .HasColumnName("MOTA")
                    .HasMaxLength(4000);

                entity.Property(e => e.Tenhhtp)
                    .IsRequired()
                    .HasColumnName("TENHHTP")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdbdmNavigation)
                    .WithMany(p => p.Hanghoathanhpham)
                    .HasForeignKey(d => d.Idbdm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKHANGHOATHA437557");
            });

            modelBuilder.Entity<Hangsx>(entity =>
            {
                entity.HasKey(e => e.Idhsx)
                    .HasName("PK__HANGSX__A60A17A374543449");

                entity.ToTable("HANGSX");

                entity.Property(e => e.Idhsx).HasColumnName("IDHSX");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Mahsx)
                    .HasColumnName("MAHSX")
                    .HasMaxLength(255);

                entity.Property(e => e.Tenhsx)
                    .IsRequired()
                    .HasColumnName("TENHSX")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Hinhthucthanhtoan>(entity =>
            {
                entity.HasKey(e => e.Idhttt)
                    .HasName("PK__HINHTHUC__9DCEA6E3E700584F");

                entity.ToTable("HINHTHUCTHANHTOAN");

                entity.Property(e => e.Idhttt).HasColumnName("IDHTTT");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Mahttt)
                    .HasColumnName("MAHTTT")
                    .HasMaxLength(255);

                entity.Property(e => e.Tenhttt)
                    .IsRequired()
                    .HasColumnName("TENHTTT")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Idkh)
                    .HasName("PK__KHACHHAN__B87DC1A780597033");

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.Idkh).HasColumnName("IDKH");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Cccd)
                    .HasColumnName("CCCD")
                    .HasMaxLength(255);

                entity.Property(e => e.Diachi)
                    .IsRequired()
                    .HasColumnName("DIACHI")
                    .HasMaxLength(4000);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.Facebook)
                    .HasColumnName("FACEBOOK")
                    .HasMaxLength(255);

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Gioitinh)
                    .IsRequired()
                    .HasColumnName("GIOITINH")
                    .HasMaxLength(255);

                entity.Property(e => e.Hinhanh)
                    .HasColumnName("HINHANH")
                    .HasMaxLength(255);

                entity.Property(e => e.Makh)
                    .HasColumnName("MAKH")
                    .HasMaxLength(255);

                entity.Property(e => e.Masothue)
                    .HasColumnName("MASOTHUE")
                    .HasMaxLength(255);

                entity.Property(e => e.Matkhau)
                    .HasColumnName("MATKHAU")
                    .HasMaxLength(255);

                entity.Property(e => e.Ngaysinh)
                    .HasColumnName("NGAYSINH")
                    .HasColumnType("date");

                entity.Property(e => e.Nvidsale).HasColumnName("NVIDSALE");

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasColumnName("SDT")
                    .HasMaxLength(255);

                entity.Property(e => e.Tenkh)
                    .IsRequired()
                    .HasColumnName("TENKH")
                    .HasMaxLength(255);

                entity.Property(e => e.Zalo)
                    .HasColumnName("ZALO")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Nganhang>(entity =>
            {
                entity.HasKey(e => e.Idnh)
                    .HasName("PK__NGANHANG__B87DC944D1DA3BFB");

                entity.ToTable("NGANHANG");

                entity.Property(e => e.Idnh).HasColumnName("IDNH");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Diachi)
                    .IsRequired()
                    .HasColumnName("DIACHI")
                    .HasMaxLength(4000);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Idhttt).HasColumnName("IDHTTT");

                entity.Property(e => e.Masothue)
                    .IsRequired()
                    .HasColumnName("MASOTHUE")
                    .HasMaxLength(255);

                entity.Property(e => e.Tennh)
                    .IsRequired()
                    .HasColumnName("TENNH")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdhtttNavigation)
                    .WithMany(p => p.Nganhang)
                    .HasForeignKey(d => d.Idhttt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNGANHANG536661");
            });

            modelBuilder.Entity<Nhacungcapvl>(entity =>
            {
                entity.HasKey(e => e.Idncc)
                    .HasName("PK__NHACUNGC__945E470556124F36");

                entity.ToTable("NHACUNGCAPVL");

                entity.Property(e => e.Idncc).HasColumnName("IDNCC");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Diachi)
                    .IsRequired()
                    .HasColumnName("DIACHI")
                    .HasMaxLength(4000);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.Facebook)
                    .HasColumnName("FACEBOOK")
                    .HasMaxLength(255);

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Mancc)
                    .HasColumnName("MANCC")
                    .HasMaxLength(255);

                entity.Property(e => e.Masothue)
                    .IsRequired()
                    .HasColumnName("MASOTHUE")
                    .HasMaxLength(255);

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasColumnName("SDT")
                    .HasMaxLength(255);

                entity.Property(e => e.Tenncc)
                    .IsRequired()
                    .HasColumnName("TENNCC")
                    .HasMaxLength(255);

                entity.Property(e => e.Zalo)
                    .HasColumnName("ZALO")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.Idnv)
                    .HasName("PK__NHANVIEN__B87DC9B2AC37118A");

                entity.ToTable("NHANVIEN");

                entity.Property(e => e.Idnv).HasColumnName("IDNV");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Cccd)
                    .HasColumnName("CCCD")
                    .HasMaxLength(255);

                entity.Property(e => e.Diachi)
                    .IsRequired()
                    .HasColumnName("DIACHI")
                    .HasMaxLength(4000);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.Facebook)
                    .HasColumnName("FACEBOOK")
                    .HasMaxLength(255);

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Gioitinh)
                    .IsRequired()
                    .HasColumnName("GIOITINH")
                    .HasMaxLength(255);

                entity.Property(e => e.Hinhanh)
                    .HasColumnName("HINHANH")
                    .HasMaxLength(255);

                entity.Property(e => e.Manv)
                    .HasColumnName("MANV")
                    .HasMaxLength(255);

                entity.Property(e => e.Masothue)
                    .HasColumnName("MASOTHUE")
                    .HasMaxLength(255);

                entity.Property(e => e.Matkhau)
                    .HasColumnName("MATKHAU")
                    .HasMaxLength(255);

                entity.Property(e => e.Ngaysinh)
                    .HasColumnName("NGAYSINH")
                    .HasColumnType("date");

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasColumnName("SDT")
                    .HasMaxLength(255);

                entity.Property(e => e.Tennv)
                    .IsRequired()
                    .HasColumnName("TENNV")
                    .HasMaxLength(255);

                entity.Property(e => e.Tosxid).HasColumnName("TOSXID");

                entity.Property(e => e.Zalo)
                    .HasColumnName("ZALO")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Nhomvl>(entity =>
            {
                entity.HasKey(e => e.Idnvl)
                    .HasName("PK__NHOMVL__945B88AAF962E46B");

                entity.ToTable("NHOMVL");

                entity.Property(e => e.Idnvl).HasColumnName("IDNVL");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Loainvl)
                    .IsRequired()
                    .HasColumnName("LOAINVL")
                    .HasMaxLength(255);

                entity.Property(e => e.Manvl)
                    .HasColumnName("MANVL")
                    .HasMaxLength(255);

                entity.Property(e => e.Tennvl)
                    .IsRequired()
                    .HasColumnName("TENNVL")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Noidungddhsx>(entity =>
            {
                entity.HasKey(e => new { e.Idhhtp, e.Iddhsx, e.Idndddhsx })
                    .HasName("PK__NOIDUNGD__B3AEEF3893E1AA4B");

                entity.ToTable("NOIDUNGDDHSX");

                entity.Property(e => e.Idhhtp).HasColumnName("IDHHTP");

                entity.Property(e => e.Iddhsx).HasColumnName("IDDHSX");

                entity.Property(e => e.Idndddhsx)
                    .HasColumnName("IDNDDDHSX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Dongia).HasColumnName("DONGIA");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.HasOne(d => d.IddhsxNavigation)
                    .WithMany(p => p.Noidungddhsx)
                    .HasForeignKey(d => d.Iddhsx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGDDH522799");

                entity.HasOne(d => d.IdhhtpNavigation)
                    .WithMany(p => p.Noidungddhsx)
                    .HasForeignKey(d => d.Idhhtp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGDDH81086");
            });

            modelBuilder.Entity<Noidungpbh>(entity =>
            {
                entity.HasKey(e => new { e.Idndpbh, e.Idpbh, e.Idvl })
                    .HasName("PK__NOIDUNGP__2595112C2D697F05");

                entity.ToTable("NOIDUNGPBH");

                entity.Property(e => e.Idndpbh)
                    .HasColumnName("IDNDPBH")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idpbh).HasColumnName("IDPBH");

                entity.Property(e => e.Idvl).HasColumnName("IDVL");

                entity.Property(e => e.Dongia).HasColumnName("DONGIA");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.HasOne(d => d.IdpbhNavigation)
                    .WithMany(p => p.Noidungpbh)
                    .HasForeignKey(d => d.Idpbh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGPBH395289");

                entity.HasOne(d => d.IdvlNavigation)
                    .WithMany(p => p.Noidungpbh)
                    .HasForeignKey(d => d.Idvl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGPBH386396");
            });

            modelBuilder.Entity<Noidungpnk>(entity =>
            {
                entity.HasKey(e => new { e.Idndpnk, e.Idpnk, e.Idvl })
                    .HasName("PK__NOIDUNGP__E594895E5473F711");

                entity.ToTable("NOIDUNGPNK");

                entity.Property(e => e.Idndpnk)
                    .HasColumnName("IDNDPNK")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idpnk).HasColumnName("IDPNK");

                entity.Property(e => e.Idvl).HasColumnName("IDVL");

                entity.Property(e => e.Dongia).HasColumnName("DONGIA");

                entity.Property(e => e.Hansd)
                    .HasColumnName("HANSD")
                    .HasColumnType("date");

                entity.Property(e => e.Ngaysx)
                    .HasColumnName("NGAYSX")
                    .HasColumnType("date");

                entity.Property(e => e.Solo)
                    .HasColumnName("SOLO")
                    .HasMaxLength(255);
                entity.Property(e => e.Donvitinh)
                    .HasColumnName("DONVITINH")
                    .HasMaxLength(255);
                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.HasOne(d => d.IdpnkNavigation)
                    .WithMany(p => p.Noidungpnk)
                    .HasForeignKey(d => d.Idpnk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGPNK363708");

                entity.HasOne(d => d.IdvlNavigation)
                    .WithMany(p => p.Noidungpnk)
                    .HasForeignKey(d => d.Idvl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGPNK386021");
            });

            modelBuilder.Entity<Noidungthunoddhsx>(entity =>
            {
                entity.HasKey(e => new { e.Idndtndhsx, e.Idptnkh, e.Iddhsx })
                    .HasName("PK__NOIDUNGT__565E04B6B05E2C11");

                entity.ToTable("NOIDUNGTHUNODDHSX");

                entity.Property(e => e.Idndtndhsx)
                    .HasColumnName("IDNDTNDHSX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idptnkh).HasColumnName("IDPTNKH");

                entity.Property(e => e.Iddhsx).HasColumnName("IDDHSX");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Ngaythuno)
                    .HasColumnName("NGAYTHUNO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sotien).HasColumnName("SOTIEN");

                entity.HasOne(d => d.IddhsxNavigation)
                    .WithMany(p => p.Noidungthunoddhsx)
                    .HasForeignKey(d => d.Iddhsx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGTHU358147");

                entity.HasOne(d => d.IdptnkhNavigation)
                    .WithMany(p => p.Noidungthunoddhsx)
                    .HasForeignKey(d => d.Idptnkh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGTHU808595");
            });

            modelBuilder.Entity<Noidungthunokh>(entity =>
            {
                entity.HasKey(e => new { e.Idndptnkh, e.Idptnkh, e.Idpbh })
                    .HasName("PK__NOIDUNGT__886D02FBB5D81F66");

                entity.ToTable("NOIDUNGTHUNOKH");

                entity.Property(e => e.Idndptnkh)
                    .HasColumnName("IDNDPTNKH")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idptnkh).HasColumnName("IDPTNKH");

                entity.Property(e => e.Idpbh).HasColumnName("IDPBH");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Ngaythuno)
                    .HasColumnName("NGAYTHUNO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sotien).HasColumnName("SOTIEN");

                entity.HasOne(d => d.IdpbhNavigation)
                    .WithMany(p => p.Noidungthunokh)
                    .HasForeignKey(d => d.Idpbh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGTHU911968");

                entity.HasOne(d => d.IdptnkhNavigation)
                    .WithMany(p => p.Noidungthunokh)
                    .HasForeignKey(d => d.Idptnkh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGTHU311955");
            });

            modelBuilder.Entity<Noidungtranoncc>(entity =>
            {
                entity.HasKey(e => new { e.Idndptnncc, e.Idptnncc, e.Idpnk })
                    .HasName("PK__NOIDUNGT__844B1FAB21C6F387");

                entity.ToTable("NOIDUNGTRANONCC");

                entity.Property(e => e.Idndptnncc)
                    .HasColumnName("IDNDPTNNCC")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idptnncc).HasColumnName("IDPTNNCC");

                entity.Property(e => e.Idpnk).HasColumnName("IDPNK");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Ngaytrano)
                    .HasColumnName("NGAYTRANO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sotien).HasColumnName("SOTIEN");

                entity.HasOne(d => d.IdpnkNavigation)
                    .WithMany(p => p.Noidungtranoncc)
                    .HasForeignKey(d => d.Idpnk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGTRA430668");

                entity.HasOne(d => d.IdptnnccNavigation)
                    .WithMany(p => p.Noidungtranoncc)
                    .HasForeignKey(d => d.Idptnncc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNOIDUNGTRA854248");
            });

            modelBuilder.Entity<Nuocsx>(entity =>
            {
                entity.HasKey(e => e.Idnsx)
                    .HasName("PK__NUOCSX__945EC524CCD8140F");

                entity.ToTable("NUOCSX");

                entity.Property(e => e.Idnsx).HasColumnName("IDNSX");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Mansx)
                    .HasColumnName("MANSX")
                    .HasMaxLength(255);

                entity.Property(e => e.Tennsx)
                    .IsRequired()
                    .HasColumnName("TENNSX")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Phieubanhang>(entity =>
            {
                entity.HasKey(e => e.Idpbh)
                    .HasName("PK__PHIEUBAN__98FEB3C4011329C0");

                entity.ToTable("PHIEUBANHANG");

                entity.Property(e => e.Idpbh).HasColumnName("IDPBH");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Idkh).HasColumnName("IDKH");

                entity.Property(e => e.Idnv).HasColumnName("IDNV");

                entity.Property(e => e.Ngayhd)
                    .HasColumnName("NGAYHD")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ngaylap)
                    .HasColumnName("NGAYLAP")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sohd)
                    .HasColumnName("SOHD")
                    .HasMaxLength(255);

                entity.Property(e => e.Sophieu)
                    .IsRequired()
                    .HasColumnName("SOPHIEU")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdkhNavigation)
                    .WithMany(p => p.Phieubanhang)
                    .HasForeignKey(d => d.Idkh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPHIEUBANHA876948");

                entity.HasOne(d => d.IdnvNavigation)
                    .WithMany(p => p.Phieubanhang)
                    .HasForeignKey(d => d.Idnv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPHIEUBANHA203472");
            });

            modelBuilder.Entity<Phieunhapkho>(entity =>
            {
                entity.HasKey(e => e.Idpnk)
                    .HasName("PK__PHIEUNHA__98FEDC48B9720037");

                entity.ToTable("PHIEUNHAPKHO");

                entity.Property(e => e.Idpnk).HasColumnName("IDPNK");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Idncc).HasColumnName("IDNCC");

                entity.Property(e => e.Idnv).HasColumnName("IDNV");

                entity.Property(e => e.Ngayhd)
                    .HasColumnName("NGAYHD")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ngaylap)
                    .HasColumnName("NGAYLAP")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sohd)
                    .HasColumnName("SOHD")
                    .HasMaxLength(255);

                entity.Property(e => e.Sophieu)
                    .IsRequired()
                    .HasColumnName("SOPHIEU")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdnccNavigation)
                    .WithMany(p => p.Phieunhapkho)
                    .HasForeignKey(d => d.Idncc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPHIEUNHAPK566183");

                entity.HasOne(d => d.IdnvNavigation)
                    .WithMany(p => p.Phieunhapkho)
                    .HasForeignKey(d => d.Idnv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPHIEUNHAPK10246");
            });

            modelBuilder.Entity<Phieuthunokh>(entity =>
            {
                entity.HasKey(e => e.Idptnkh)
                    .HasName("PK__PHIEUTHU__02AF4104057EFD46");

                entity.ToTable("PHIEUTHUNOKH");

                entity.Property(e => e.Idptnkh).HasColumnName("IDPTNKH");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Idhttt).HasColumnName("IDHTTT");

                entity.Property(e => e.Idnv).HasColumnName("IDNV");

                entity.Property(e => e.Ngaylap)
                    .HasColumnName("NGAYLAP")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sophieu)
                    .IsRequired()
                    .HasColumnName("SOPHIEU")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdhtttNavigation)
                    .WithMany(p => p.Phieuthunokh)
                    .HasForeignKey(d => d.Idhttt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPHIEUTHUNO674725");

                entity.HasOne(d => d.IdnvNavigation)
                    .WithMany(p => p.Phieuthunokh)
                    .HasForeignKey(d => d.Idnv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPHIEUTHUNO460360");
            });

            modelBuilder.Entity<Phieutranoncc>(entity =>
            {
                entity.HasKey(e => e.Idptnncc)
                    .HasName("PK__PHIEUTRA__B57294B7CFF9D576");

                entity.ToTable("PHIEUTRANONCC");

                entity.Property(e => e.Idptnncc).HasColumnName("IDPTNNCC");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Idhttt).HasColumnName("IDHTTT");

                entity.Property(e => e.Idnv).HasColumnName("IDNV");

                entity.Property(e => e.Ngaylap)
                    .HasColumnName("NGAYLAP")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sophieu)
                   
                    .HasColumnName("SOPHIEU")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdhtttNavigation)
                    .WithMany(p => p.Phieutranoncc)
                    .HasForeignKey(d => d.Idhttt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPHIEUTRANO140505");

                entity.HasOne(d => d.IdnvNavigation)
                    .WithMany(p => p.Phieutranoncc)
                    .HasForeignKey(d => d.Idnv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPHIEUTRANO695999");
            });

            modelBuilder.Entity<Tosanxuat>(entity =>
            {
                entity.HasKey(e => e.Idtsx)
                    .HasName("PK__TOSANXUA__A70204AD58CAA4F3");

                entity.ToTable("TOSANXUAT");

                entity.Property(e => e.Idtsx).HasColumnName("IDTSX");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(4000);

                entity.Property(e => e.Idgdsx).HasColumnName("IDGDSX");

                entity.Property(e => e.Matsx)
                    .HasColumnName("MATSX")
                    .HasMaxLength(255);

                entity.Property(e => e.Tentsx)
                    .IsRequired()
                    .HasColumnName("TENTSX")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdgdsxNavigation)
                    .WithMany(p => p.Tosanxuat)
                    .HasForeignKey(d => d.Idgdsx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTOSANXUAT416845");
            });

            modelBuilder.Entity<Vatlieu>(entity =>
            {
                entity.HasKey(e => e.Idvl)
                    .HasName("PK__VATLIEU__B87C0A42BF29C2A8");

                entity.ToTable("VATLIEU");

                entity.Property(e => e.Idvl).HasColumnName("IDVL");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Giaban).HasColumnName("GIABAN");

                entity.Property(e => e.Idhsx).HasColumnName("IDHSX");

                entity.Property(e => e.Idnsx).HasColumnName("IDNSX");

                entity.Property(e => e.Idnvl).HasColumnName("IDNVL");

                entity.Property(e => e.Mavl)
                    .HasColumnName("MAVL")
                    .HasMaxLength(255);

                entity.Property(e => e.Quycach)
                    .IsRequired()
                    .HasColumnName("QUYCACH")
                    .HasMaxLength(255);

                entity.Property(e => e.Tenvl)
                    .IsRequired()
                    .HasColumnName("TENVL")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdhsxNavigation)
                    .WithMany(p => p.Vatlieu)
                    .HasForeignKey(d => d.Idhsx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKVATLIEU504386");

                entity.HasOne(d => d.IdnsxNavigation)
                    .WithMany(p => p.Vatlieu)
                    .HasForeignKey(d => d.Idnsx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKVATLIEU221391");

                entity.HasOne(d => d.IdnvlNavigation)
                    .WithMany(p => p.Vatlieu)
                    .HasForeignKey(d => d.Idnvl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKVATLIEU217323");
            });

            modelBuilder.Entity<Vatlieusxbd>(entity =>
            {
                entity.HasKey(e => new { e.Idvlsxbd, e.Idbdm, e.Idvl })
                    .HasName("PK__VATLIEUS__8809B12C11C19615");

                entity.ToTable("VATLIEUSXBD");

                entity.Property(e => e.Idvlsxbd)
                    .HasColumnName("IDVLSXBD")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idbdm).HasColumnName("IDBDM");

                entity.Property(e => e.Idvl).HasColumnName("IDVL");

                entity.Property(e => e.Dongiadm).HasColumnName("DONGIADM");

                entity.Property(e => e.Donvitinh)
                    .IsRequired()
                    .HasColumnName("DONVITINH")
                    .HasMaxLength(255);

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.HasOne(d => d.IdbdmNavigation)
                    .WithMany(p => p.Vatlieusxbd)
                    .HasForeignKey(d => d.Idbdm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKVATLIEUSXB254823");

                entity.HasOne(d => d.IdvlNavigation)
                    .WithMany(p => p.Vatlieusxbd)
                    .HasForeignKey(d => d.Idvl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKVATLIEUSXB738265");
            });

            modelBuilder.Entity<Vatlieusxtt>(entity =>
            {
                entity.HasKey(e => new { e.Idvlsxtt, e.Idhhtp, e.Idvl })
                    .HasName("PK__VATLIEUS__4E84EE61B779CC48");

                entity.ToTable("VATLIEUSXTT");

                entity.Property(e => e.Idvlsxtt)
                    .HasColumnName("IDVLSXTT")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idhhtp).HasColumnName("IDHHTP");

                entity.Property(e => e.Idvl).HasColumnName("IDVL");

                entity.Property(e => e.Donvitinh)
                    .IsRequired()
                    .HasColumnName("DONVITINH")
                    .HasMaxLength(255);

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.HasOne(d => d.IdhhtpNavigation)
                    .WithMany(p => p.Vatlieusxtt)
                    .HasForeignKey(d => d.Idhhtp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKVATLIEUSXT183242");

                entity.HasOne(d => d.IdvlNavigation)
                    .WithMany(p => p.Vatlieusxtt)
                    .HasForeignKey(d => d.Idvl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKVATLIEUSXT738839");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
