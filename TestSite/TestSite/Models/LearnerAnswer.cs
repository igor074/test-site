namespace TestSite.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    
    public class LearnerAnswer
    {
        public int QuestionID { get; set; }
        public Question Question { get; set; }

        public int Id { get; set; }
        public IdentityUser Learner { get; set; }

        public int AnswerID { get; set; }
        public Answer Answer { get; set; }

        public string LearnerAnswer1 { get; set; }
    }
}
