using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestSite.Models
{
    public class QuestionModelView
    {
        private Question _question;

        public int QuestionTypeID { get; set; }
        [Display(Name = "Текст вопроса")]
        public string Text { get; set; }
        public int CountAnswers { get; set; }
        public bool IsRight { get; set; }

        public QuestionModelView() 
        {
            _question = new Question();
        }

        public QuestionModelView(Question question, int questionTypeId)
        {
            _question = question;
            QuestionTypeID = questionTypeId;
            ParseQuestion();
        }

        private void ParseQuestion()
        {
            if (_question == null)
                return;

            switch (QuestionTypeID)
            {
                case 5:
                {
                    Text = _question.Text;
                    break;
                }
            }
        }
    }
}