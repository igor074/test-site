//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestSite.Diagrams
{
    using System;
    using System.Collections.Generic;
    
    public partial class AnswerQuestions
    {
        public int AnswerID { get; set; }
        public int QuestionID { get; set; }
        public Nullable<bool> IsRight { get; set; }
        public Nullable<int> Question_QuestionID { get; set; }
        public Nullable<int> Question_QuestionAreaID { get; set; }
        public Nullable<int> Question_QuestionTypeID { get; set; }
    
        public virtual Answers Answers { get; set; }
        public virtual Questions Questions { get; set; }
    }
}
