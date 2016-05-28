using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IQuestionLib
{
    public interface IQuestion
    {
        TypeQuestion Type { get; set; }
        UserControl ControlQuestion { get; }
        void SetData(List<Otvety> list);
        bool GetAnswer();
    }

    public enum TypeQuestion
    {
        OneVariant = 0,
        MoreOneVariant = 1,
        Graphic = 2,
        LogicRelation = 3,
        FullAnswer = 4,
        Matching = 5,
        Compare = 6,
        InsertWords = 7,
        Selection = 8,
        ChroniceSequence = 9
    }
}
