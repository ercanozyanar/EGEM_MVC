﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EGEM_MVC.Models.EntityEgem
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EGEM2023Entities : DbContext
    {
        public EGEM2023Entities()
            : base("name=EGEM2023Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EGEM_DEPO_VARDIYA> EGEM_DEPO_VARDIYA { get; set; }
        public virtual DbSet<EGEM_KALITE_VARDIYA> EGEM_KALITE_VARDIYA { get; set; }
        public virtual DbSet<EO_GRAVUR_VARDIYA> EO_GRAVUR_VARDIYA { get; set; }
        public virtual DbSet<EGEM_ESNEK_BASKI_KALITE> EGEM_ESNEK_BASKI_KALITE { get; set; }
        public virtual DbSet<EGEM_ESNEK_DILIMLEME_KALITE> EGEM_ESNEK_DILIMLEME_KALITE { get; set; }
        public virtual DbSet<EGEM_ESNEK_LAMINASYON_KALITE> EGEM_ESNEK_LAMINASYON_KALITE { get; set; }
        public virtual DbSet<EGEM_GRAVUR_KALITE> EGEM_GRAVUR_KALITE { get; set; }
        public virtual DbSet<EGEM_OFSET_BASKI_KALITE> EGEM_OFSET_BASKI_KALITE { get; set; }
        public virtual DbSet<EGEM_OFSET_BITIRME_KALITE> EGEM_OFSET_BITIRME_KALITE { get; set; }
        public virtual DbSet<EGEM_ORJINAL_IMAJ> EGEM_ORJINAL_IMAJ { get; set; }
        public virtual DbSet<EGEM_DOF_TAKIP> EGEM_DOF_TAKIP { get; set; }
        public virtual DbSet<EGEM_DOFLIST> EGEM_DOFLIST { get; set; }
        public virtual DbSet<EGEM_PROJESILINDIR_TALEP> EGEM_PROJESILINDIR_TALEP { get; set; }
        public virtual DbSet<EGEM_MVC_USER> EGEM_MVC_USER { get; set; }
    }
}
