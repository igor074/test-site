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
    public partial class PanelMoreOneVariant : UserControl, IQuestionLib.IQuestionData
    {
        public PanelMoreOneVariant()
        {
            InitializeComponent();
        }

        public List<Otvety> GetData()
        {
            List<Otvety> res = new List<Otvety>();
            res.Add(new Otvety() { isWright = false, textOtveta = textBox1.Text });
            foreach (object item in checkedListBox1.Items)
            {
                Otvety o = new Otvety();
                o.isWright = checkedListBox1.GetItemCheckState(checkedListBox1.Items.IndexOf(item)) == CheckState.Checked ? true : false;
                o.textOtveta = checkedListBox1.Items[checkedListBox1.Items.IndexOf(item)].ToString();
                res.Add(o);
            }
            return res;
        }

        public void SetData(List<Otvety> data)
        {
            textBox1.Text = data[0].textOtveta;
            string[] t = data[1].textOtveta.Split('|');
            for (int i = 0; i < t.GetLength(0); i++)
            {
                checkedListBox1.Items.Add(t[i]);
            }
            OnChangedProperty(IQuestionLib.TypeQuestion.MoreOneVariant);
        }

        public event IQuestionLib.ChangeProperty OnChangedProperty;

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            OnChangedProperty(IQuestionLib.TypeQuestion.MoreOneVariant);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.Items.Count < 9)
            {
                checkedListBox1.Items.Add(textBox2.Text);
                OnChangedProperty(IQuestionLib.TypeQuestion.MoreOneVariant);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex > -1)
            {
                checkedListBox1.Items.RemoveAt(checkedListBox1.SelectedIndex);
                OnChangedProperty(IQuestionLib.TypeQuestion.MoreOneVariant);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OnChangedProperty(IQuestionLib.TypeQuestion.MoreOneVariant);
        }
    }
}
