using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class FormChooseType : Form
    {
        public FormChooseType()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormChooseTest form = new FormChooseTest();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormUserTestingAdd form = new FormUserTestingAdd(19);
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormUserTestingOlimp form = new FormUserTestingOlimp(14);
            form.ShowDialog();
        }
    }
}
