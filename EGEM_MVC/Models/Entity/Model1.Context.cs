﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EGEM_MVC.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PILOTEntities : DbContext
    {
        public PILOTEntities()
            : base("name=PILOTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EGEM_10_DEPO_BAKIYE> EGEM_10_DEPO_BAKIYE { get; set; }
        public virtual DbSet<EGEM_1003_DEPO_BAKIYE> EGEM_1003_DEPO_BAKIYE { get; set; }
        public virtual DbSet<EGEM_1004_DEPO_BAKIYE> EGEM_1004_DEPO_BAKIYE { get; set; }
        public virtual DbSet<EGEM_104_DEPO_BAKIYE> EGEM_104_DEPO_BAKIYE { get; set; }
        public virtual DbSet<EGEM_99_DEPO_BAKIYE> EGEM_99_DEPO_BAKIYE { get; set; }
    }
}