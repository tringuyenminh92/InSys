//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InSys.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_PercentQuestion
    {
        public int PercentQuestionId { get; set; }
        public double PercentQuestion { get; set; }
        public string Code { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<int> LevelCadidateId { get; set; }
        public Nullable<int> LevelQuestionId { get; set; }
    
        public virtual T_LevelCandidate T_LevelCandidate { get; set; }
        public virtual T_LevelQuestionMaster T_LevelQuestionMaster { get; set; }
    }
}