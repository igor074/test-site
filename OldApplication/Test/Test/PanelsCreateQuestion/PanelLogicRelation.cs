using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IQuestionLib;

namespace Test.PanelsCreateQuestion
{
    public partial class PanelLogicRelation : UserControl, IQuestionLib.IQuestionData
    {
        public PanelLogicRelation()
        {
            InitializeComponent();
        }

        public List<Otvety> GetData()
        {
            if (textBox1.Lines.GetLength(0) == 5 && textBox2.Lines.GetLength(0) == 5)
            {
                List<Otvety> res = new List<Otvety>();
                Otvety o = new Otvety();
                o.isWright = false;
                o.textOtveta = String.Join("|", textBox1.Lines);
                res.Add(o);
                o = new Otvety();
                o.isWright = true;
                o.textOtveta = String.Join("|", textBox2.Lines);
                res.Add(o);
                return res;
            }
            return null;
        }

        public void SetData(List<Otvety> data)
        {
            if (data != null)
            {
                textBox1.Lines = data[0].textOtveta.Split('|');
                textBox2.Lines = data[1].textOtveta.Split('|');
            }
        }

        public event IQuestionLib.ChangeProperty OnChangedProperty;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OnChangedProperty(TypeQuestion.LogicRelation);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            OnChangedProperty(TypeQuestion.LogicRelation);
        }
    }
}
