namespace TestSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Olympiad
    {
        public int OlympiadID { get; set; }
        public string Subject { get; set; }
        public string Status { get; set; }
        public Nullable<bool> Condition { get; set; }
    }
}
