using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQuestionLib
{
    public delegate void ChangeProperty(TypeQuestion type);

    public interface IQuestionData
    {
        List<Otvety> GetData();
        void SetData(List<Otvety> data);
        event ChangeProperty OnChangedProperty;
    }
}
