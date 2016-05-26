namespace TestSite.Models
{
    using System;
    using System.Collections.Generic;

    public class QuestionArea
    {
        public int QuestionAreaID { get; set; }
        public string QuestionAreaName { get; set; }
        public double Possibility { get; set; }
        public int ParentQuestionAreaID { get; set; }

        public ICollection<Question> Questions { get; set; }

        public QuestionArea()
        {
            Questions = new List<Question>();
        }
    }
}
