namespace TestSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Institution
    {
        public int InstitutionID { get; set; }
        public string InstitutionName { get; set; }
        public string InstitutionPlace { get; set; }
        public string InstitutionAddress { get; set; }

        public ICollection<Group> Groups { get; set; }

        public Institution()
        {
            Groups = new List<Group>();
        }
    }
}
