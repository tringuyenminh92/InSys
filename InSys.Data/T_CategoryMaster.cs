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
    public partial class T_CategoryMaster : Entity
    {
        public T_CategoryMaster()
        {
            this.T_Question = new HashSet<T_Question>();
        }
    
        public int CategoryId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string GroupName { get; set; }
    
        public virtual ICollection<T_Question> T_Question { get; set; }
    }

}
