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

namespace Compare
{
    public partial class Compare: UserControl, IQuestion
    {
        private string right;
        private TypeQuestion _type = TypeQuestion.Compare;

        public TypeQuestion Type
        {
            get { return TypeQuestion.Compare; }
            set { _type = value; }
        }
        public Compare()
        {
            InitializeComponent();
            comboBox2.SelectedIndex = 0;
        }


        public void SetData(List<Otvety> list)
        {
            if (list != null)
            {
                string[] leftRight = list[0].textOtveta.Split('|');
                label2.Text = leftRight[0];
                label3.Text = leftRight[1];
                if (comboBox2.SelectedItem.ToString() == list[1].textOtveta)
                {
                    comboBox2.SelectedIndex = comboBox2.Items.IndexOf(comboBox2.SelectedItem) + 1;
                }
                right = list[1].textOtveta;
            }
        }

        public bool GetAnswer()
        {
            return (right == comboBox2.SelectedItem.ToString());
        }

        public UserControl ControlQuestion
        {
            get { return new Compare(); }
        }

        private void Compare_Load(object sender, EventArgs e)
        {
            
        }
    }
}
