﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarketStack_2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MarketStackEntities : DbContext
    {
        public MarketStackEntities()
            : base("name=MarketStackEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<End_Of_Day> End_Of_Day { get; set; }
        public virtual DbSet<End_Of_Day_Data> End_Of_Day_Data { get; set; }
        public virtual DbSet<Historical> Historicals { get; set; }
        public virtual DbSet<Historical_Data> Historical_Data { get; set; }
        public virtual DbSet<IntraDay> IntraDays { get; set; }
        public virtual DbSet<IntraDay_Data> IntraDay_Data { get; set; }
    }
}
