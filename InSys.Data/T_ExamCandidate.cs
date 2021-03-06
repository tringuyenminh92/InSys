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
    
    using InSys.Repository.Pattern.Ef6;
    public partial class T_ExamCandidate : Entity
    {
        public T_ExamCandidate()
        {
            this.T_Result = new HashSet<T_Result>();
        }
    
        public System.Guid ExamCadidateId { get; set; }
        public Nullable<System.Guid> ExamId { get; set; }
        public Nullable<System.Guid> CandidateId { get; set; }
        public Nullable<System.DateTime> TimeStartExam { get; set; }
        public Nullable<double> TimeDo { get; set; }
        public Nullable<double> Point { get; set; }
        public Nullable<bool> IsPass { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public string Code { get; set; }
        public string CandidateName { get; set; }
        public string ExamCode { get; set; }
    
        public virtual T_Candidate T_Candidate { get; set; }
        public virtual T_Exam T_Exam { get; set; }
        public virtual ICollection<T_Result> T_Result { get; set; }
    }

}
