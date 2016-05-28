namespace TestSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Question
    {
        public int QuestionID { get; set; }

        [Display(Name = "Тип вопроса")]
        public int QuestionTypeID { get; set; }
        [Display(Name = "Тип вопроса")]
        public QuestionType QuestionType { get; set; }

        [Display(Name = "Область вопроса")]
        public int QuestionAreaID { get; set; }
        [Display(Name = "Область вопроса")]
        public QuestionArea QuestionArea { get; set; }

        public ICollection<Test> Tests { get; set; }

        [Display(Name = "Сложность")]
        public Nullable<int> Complexity { get; set; }
        public string Text { get; set; }

        [Display(Name = "Время на выполнение")]
        public Nullable<int> SolvingTime { get; set; }

        [Display(Name = "Баллы")]
        public Nullable<int> Points { get; set; }

        public string ImagePath { get; set; }

        public Question()
        {
            Tests = new List<Test>();
        }
        
    }
}
