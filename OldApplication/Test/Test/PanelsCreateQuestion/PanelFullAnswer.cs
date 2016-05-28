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
    public partial class PanelFullAnswer : UserControl, IQuestionLib.IQuestionData
    {
        public PanelFullAnswer()
        {
            InitializeComponent();
        }

        public List<Otvety> GetData()
        {
            Otvety o = new Otvety();
            o.textOtveta = textBox1.Text;
            o.isWright = false;
            return new List<Otvety>() { o };
        }

        public void SetData(List<Otvety> data)
        {
            if(data != null)
                textBox1.Text = data[0].textOtveta;
        }

        public event IQuestionLib.ChangeProperty OnChangedProperty;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OnChangedProperty(TypeQuestion.FullAnswer);
        }
    }
}
