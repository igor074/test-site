//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestSite.Diagrams
{
    using System;
    using System.Collections.Generic;
    
    public partial class Groups
    {
        public Groups()
        {
            this.IdentityUsers = new HashSet<IdentityUsers>();
        }
    
        public int GroupID { get; set; }
        public int InstitutionID { get; set; }
        public string GroupName { get; set; }
    
        public virtual Institutions Institutions { get; set; }
        public virtual ICollection<IdentityUsers> IdentityUsers { get; set; }
    }
}
