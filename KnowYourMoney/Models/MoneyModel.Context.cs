﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KnowYourMoney.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IST421JimTeam3Entities : DbContext
    {
        public IST421JimTeam3Entities()
            : base("name=IST421JimTeam3Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tblAccountInfo> tblAccountInfoes { get; set; }
        public virtual DbSet<tblAccountSummary> tblAccountSummaries { get; set; }
        public virtual DbSet<tblBudget> tblBudgets { get; set; }
        public virtual DbSet<tblDeposit> tblDeposits { get; set; }
        public virtual DbSet<tblExpens> tblExpenses { get; set; }
        public virtual DbSet<tblSaving> tblSavings { get; set; }
        public virtual DbSet<tblTransaction> tblTransactions { get; set; }
        public virtual DbSet<tblWithdraw> tblWithdraws { get; set; }
    }
}
