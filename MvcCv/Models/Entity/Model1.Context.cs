﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcCv.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbCvEntities : DbContext
    {
        public DbCvEntities()
            : base("name=DbCvEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBLadmin> TBLadmin { get; set; }
        public virtual DbSet<TBLdeneyimlerim> TBLdeneyimlerim { get; set; }
        public virtual DbSet<TBLegitimlerim> TBLegitimlerim { get; set; }
        public virtual DbSet<TBLhakkinda> TBLhakkinda { get; set; }
        public virtual DbSet<TBLhobiler> TBLhobiler { get; set; }
        public virtual DbSet<TBLiletisim> TBLiletisim { get; set; }
        public virtual DbSet<TBLsertifikalar> TBLsertifikalar { get; set; }
        public virtual DbSet<TBLyetenekler> TBLyetenekler { get; set; }
        public virtual DbSet<TBLsosyalmedya> TBLsosyalmedya { get; set; }
        public virtual DbSet<TBLsertifikaGaleri> TBLsertifikaGaleri { get; set; }
    }
}
