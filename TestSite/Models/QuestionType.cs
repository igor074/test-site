namespace TestSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public class QuestionType
    {
        public string QuestionTypeName { get; set; }
        public int QuestionTypeID { get; set; }

        public ICollection<Question> Questions { get; set; }

        public QuestionType()
        {
            Questions = new List<Question>();
        }
    }
}
