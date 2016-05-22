namespace TestSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public class LearnerAnswer
    {
        public int OlympiadID { get; set; }
        public Olympiad Olympiad { get; set; }

        public int QuestionID { get; set; }
        public Question Question { get; set; }

        public int LearnerID { get; set; }
        public Learner Learner { get; set; }

        public int AnswerID { get; set; }
        public Answer Answer { get; set; }

        public string LearnerAnswer1 { get; set; }
    }
}
