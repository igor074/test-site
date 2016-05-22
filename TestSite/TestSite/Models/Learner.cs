namespace TestSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Learner
    {
        public int LearnerID { get; set; }
        
        public int InstitutionID { get; set; }
        public Institution Institution { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}
