﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cunstudio.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CunstudioEntities : DbContext
    {
        public CunstudioEntities()
            : base("name=CunstudioEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Anh> Anhs { get; set; }
        public virtual DbSet<GoiDichVu> GoiDichVus { get; set; }
        public virtual DbSet<GopYKH> GopYKHs { get; set; }
        public virtual DbSet<HopDong> HopDongs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<SuaAnhTheoYC> SuaAnhTheoYCs { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
    }
}
