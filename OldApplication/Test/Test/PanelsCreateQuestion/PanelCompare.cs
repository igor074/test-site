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
    public partial class PanelCompare : UserControl, IQuestionData
    {
        public PanelCompare()
        {
            InitializeComponent();
            
        }

        public List<Otvety> GetData()
        {
            Otvety o = new Otvety();
            o.isWright = false;
            o.textOtveta = textBox1.Text + "|" + textBox2.Text;
            Otvety o1 = new Otvety();
            o1.isWright = true;
            o1.textOtveta = comboBox1.SelectedItem.ToString();
            return new List<Otvety>() { o, o1 };
        }


        public void SetData(List<Otvety> data)
        {
            string[] leftRight = data[0].textOtveta.Split('|');
            textBox1.Text = leftRight[0];
            textBox2.Text = leftRight[1];
            comboBox1.SelectedItem = data[1].textOtveta;
        }

        public event ChangeProperty OnChangedProperty;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OnChangedProperty(TypeQuestion.Compare);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            OnChangedProperty(TypeQuestion.Compare);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnChangedProperty(TypeQuestion.Compare);
        }

        private void PanelCompare_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
    }
}
