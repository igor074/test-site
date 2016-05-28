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
using System.Collections;

namespace Test.PanelsCreateQuestion
{
    public partial class PanelChronice : UserControl, IQuestionLib.IQuestionData
    {
        public PanelChronice()
        {
            InitializeComponent();
        }

        public List<Otvety> GetData()
        {
            List<Otvety> res = new List<Otvety>();
            Otvety o = new Otvety();
            o.isWright = true;
            o.textOtveta = String.Join("|", textBox1.Lines);
            res.Add(o);
            return res;
        }

        public void SetData(List<Otvety> data)
        {
            if (data != null)
            {
                textBox1.Lines = data[0].textOtveta.Split('|');
            }
        }

        public event IQuestionLib.ChangeProperty OnChangedProperty;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OnChangedProperty(TypeQuestion.ChroniceSequence);
        }
    }
}
