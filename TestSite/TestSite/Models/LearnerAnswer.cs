namespace TestSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public class LearnerAnswer
    {
        public int QuestionID { get; set; }
        public Question Question { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

        public int AnswerID { get; set; }
        public Answer Answer { get; set; }

        public string LearnerAnswer1 { get; set; }
    }
}
