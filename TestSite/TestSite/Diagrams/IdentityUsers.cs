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
    
    public partial class IdentityUsers
    {
        public IdentityUsers()
        {
            this.IdentityUserClaims = new HashSet<IdentityUserClaims>();
            this.IdentityUserLogins = new HashSet<IdentityUserLogins>();
            this.IdentityUserRoles = new HashSet<IdentityUserRoles>();
            this.LearnerAnswers = new HashSet<LearnerAnswers>();
        }
    
        public string Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public Nullable<int> GroupID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Discriminator { get; set; }
        public Nullable<int> Group_GroupID { get; set; }
        public Nullable<int> Group_InstitutionID { get; set; }
    
        public virtual Groups Groups { get; set; }
        public virtual ICollection<IdentityUserClaims> IdentityUserClaims { get; set; }
        public virtual ICollection<IdentityUserLogins> IdentityUserLogins { get; set; }
        public virtual ICollection<IdentityUserRoles> IdentityUserRoles { get; set; }
        public virtual ICollection<LearnerAnswers> LearnerAnswers { get; set; }
    }
}
