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
    public partial class T_Question : Entity
    {
        public T_Question()
        {
            this.T_Answer = new HashSet<T_Answer>();
            this.T_ExamQuestion = new HashSet<T_ExamQuestion>();
        }
    
        public System.Guid QuestionId { get; set; }
        public Nullable<int> LevelQuestionId { get; set; }
        public string LevelName { get; set; }
        public string CategoryName { get; set; }
        public string Type { get; set; }
        public string Skill { get; set; }
        public Nullable<double> Time { get; set; }
        public string ContentQuestion { get; set; }
        public Nullable<System.Guid> ApproveBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<bool> Valid { get; set; }
        public string ImagePath { get; set; }
        public string AudioPath { get; set; }
        public string VideoPath { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public string Code { get; set; }
        public Nullable<double> Point { get; set; }
        public string Tags { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public string CreateByName { get; set; }
    
        public virtual ICollection<T_Answer> T_Answer { get; set; }
        public virtual T_CategoryMaster T_CategoryMaster { get; set; }
        public virtual ICollection<T_ExamQuestion> T_ExamQuestion { get; set; }
        public virtual T_LevelQuestionMaster T_LevelQuestionMaster { get; set; }
        public virtual T_UserMaster T_UserMaster { get; set; }
    }

}
