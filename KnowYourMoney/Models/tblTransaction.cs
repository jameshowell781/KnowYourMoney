//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class tblTransaction
    {
        public tblTransaction()
        {
            this.tblAccountSummaries = new HashSet<tblAccountSummary>();
            this.tblExpenses = new HashSet<tblExpens>();
        }
    
        public int TransactionID { get; set; }
        public int UserID { get; set; }
        public string Merchant { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Category { get; set; }
        public string Notes { get; set; }
        public Nullable<decimal> Spent { get; set; }
    
        public virtual tblAccountInfo tblAccountInfo { get; set; }
        public virtual ICollection<tblAccountSummary> tblAccountSummaries { get; set; }
        public virtual ICollection<tblExpens> tblExpenses { get; set; }
    }
}
