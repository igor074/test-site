namespace TestSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Question
    {
        public int QuestionID { get; set; }

        public int QuestionTypeID { get; set; }
        public QuestionType QuestionType { get; set; }

        public int QuestionAreaID { get; set; }
        public QuestionArea QuestionArea { get; set; }

        public ICollection<Test> Tests { get; set; }

        public Nullable<int> Complexity { get; set; }
        public string Text { get; set; }

        public Nullable<int> SolvingTime { get; set; }

        public Nullable<int> Points { get; set; }
        public string ImagePath { get; set; }

        public Question()
        {
            Tests = new List<Test>();
        }
        
    }
}
