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
    public partial class PanelInsertWord : UserControl, IQuestionLib.IQuestionData
    {
        public PanelInsertWord()
        {
            InitializeComponent();
        }

        public List<Otvety> GetData()
        {
            List<Otvety> res = new List<Otvety>();
            Otvety o = new Otvety();
            o.isWright = false;
            o.textOtveta = textBox1.Text;
            res.Add(o);
            foreach (string s in textBox2.Lines)
            {
                Otvety o1 = new Otvety();
                o1.isWright = true;
                o1.textOtveta = s;
                res.Add(o1);
            }
            return res;
        }

        public void SetData(List<Otvety> data)
        {
            textBox1.Text = data[0].textOtveta;
            for (int i = 1; i < data.Count; i++)
            {
                textBox2.Text += data[i].textOtveta + "\r\n";
            }
        }

        public event IQuestionLib.ChangeProperty OnChangedProperty;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OnChangedProperty(TypeQuestion.InsertWords);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            OnChangedProperty(TypeQuestion.InsertWords);
        }
    }
}
