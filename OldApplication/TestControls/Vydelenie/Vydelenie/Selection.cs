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

namespace Selection
{
    public partial class Selection: UserControl, IQuestion
    {
        private TypeQuestion _type = TypeQuestion.Selection;

        public TypeQuestion Type
        {
            get { return TypeQuestion.Selection; }
            set { _type = value; }
        }
        bool isDown;
        string ee;
        List<string> list;
        List<string> right;
        public Selection()
        {
            InitializeComponent();
            list = new List<string>();
            right = new List<string>();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if(isDown)
                ee = richTextBox1.SelectedText;
        }

        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;
        }

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
            if (ee != string.Empty)
            {

                list.Add(ee);
                SetList();
            }
        }
        private void SetList()
        {
            textBox1.Text = string.Empty;
            foreach (string s in list)
            {
                textBox1.Text += s + " ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (list.Count > 0)
            {
                list.RemoveAt(list.Count - 1);
                SetList();
            }
        }


        public void SetData(List<Otvety> _list)
        {
            if (_list != null)
            {
                string[] t = _list[0].textOtveta.Split('|');
                label1.Text = t[0];
                richTextBox1.Text = t[1];
                for (int i = 1; i < _list.Count; i++)
                    right.Add(_list[i].textOtveta);
            }
        }

        public bool GetAnswer()
        {
            bool b = Enumerable.SequenceEqual(right, list);
            return b;
        }

        public UserControl ControlQuestion
        {
            get { return new Selection(); }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
