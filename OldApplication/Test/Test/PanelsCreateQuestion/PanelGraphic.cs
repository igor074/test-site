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
    public partial class PanelGraphic : UserControl, IQuestionLib.IQuestionData
    {
        public PanelGraphic()
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
            if (data != null)
            {
                textBox1.Text = data[0].textOtveta;
                for (int i = 1; i < data.Count; i++)
                {
                    checkedListBox1.Items.Add(data[i].textOtveta, data[i].isWright);
                }
                OnChangedProperty(TypeQuestion.Graphic);
            }
        }

        public event IQuestionLib.ChangeProperty OnChangedProperty;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Filter = "Файлы изображений (*.jpg, *.bmp)|*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                checkedListBox1.Items.Add(ofd.FileName);
                OnChangedProperty(TypeQuestion.Graphic);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex > -1)
            {
                checkedListBox1.Items.RemoveAt(checkedListBox1.SelectedIndex);
                OnChangedProperty(TypeQuestion.Graphic);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OnChangedProperty(TypeQuestion.Graphic);
        }
    }
}
