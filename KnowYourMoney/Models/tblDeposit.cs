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
    
    public partial class tblDeposit
    {
        public tblDeposit()
        {
            this.tblAccountSummaries = new HashSet<tblAccountSummary>();
        }
    
        public int DepositID { get; set; }
        public int UserID { get; set; }
        public Nullable<decimal> DepositAmount { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual tblAccountInfo tblAccountInfo { get; set; }
        public virtual ICollection<tblAccountSummary> tblAccountSummaries { get; set; }
    }
}
