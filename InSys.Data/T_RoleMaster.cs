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
    public partial class T_RoleMaster : Entity
    {
        public T_RoleMaster()
        {
            this.T_UserMaster = new HashSet<T_UserMaster>();
        }
    
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    
        public virtual ICollection<T_UserMaster> T_UserMaster { get; set; }
    }

}
