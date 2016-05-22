namespace TestSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public class AnswerQuestion
    {
        public int QuestionID { get; set; }
        public Question Question { get; set; }

        public int AnswerID { get; set; }
        public Answer Answer { get; set; }

        public Nullable<bool> IsRight { get; set; }
    }
}
