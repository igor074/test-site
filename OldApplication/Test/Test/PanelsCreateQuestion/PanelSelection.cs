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
    public partial class PanelSelection : UserControl, IQuestionLib.IQuestionData
    {
        public PanelSelection()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OnChangedProperty(TypeQuestion.Selection);
        }

        public List<Otvety> GetData()
        {
            List<Otvety> res = new List<Otvety>();
            Otvety o = new Otvety();
            o.isWright = false;
            o.textOtveta = textBox1.Text + "|" + textBox2.Text;
            res.Add(o);
            foreach(string s in textBox3.Lines)
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
            string[] t = data[0].textOtveta.Split('|');
            textBox1.Text = t[0];
            textBox2.Text = t[1];
            for (int i = 1; i < data.Count; i++)
            {
                if (i == data.Count - 1)
                {
                    textBox3.Text = data[i].textOtveta;
                    return;
                }
                textBox3.Text = data[i] + "\r\n";
            }
        }

        public event IQuestionLib.ChangeProperty OnChangedProperty;

        private void textBox1_TxtChanged(object sender, EventArgs e)
        {
            OnChangedProperty(TypeQuestion.Selection);
        }
    }
}
