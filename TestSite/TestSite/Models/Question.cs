namespace TestSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Question
    {
        public int QuestionID { get; set; }

        [Display(Name = "��� �������")]
        public int QuestionTypeID { get; set; }
        [Display(Name = "��� �������")]
        public QuestionType QuestionType { get; set; }

        [Display(Name = "������� �������")]
        public int QuestionAreaID { get; set; }
        [Display(Name = "������� �������")]
        public QuestionArea QuestionArea { get; set; }

        public ICollection<Test> Tests { get; set; }

        [Display(Name = "���������")]
        public Nullable<int> Complexity { get; set; }
        public string Text { get; set; }

        [Display(Name = "����� �� ����������")]
        public Nullable<int> SolvingTime { get; set; }

        [Display(Name = "�����")]
        public Nullable<int> Points { get; set; }

        public string ImagePath { get; set; }

        public Question()
        {
            Tests = new List<Test>();
        }
        
    }
}
