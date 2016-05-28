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
    public partial class FormChooseTest : Form
    {
        public FormChooseTest()
        {
            InitializeComponent();
        }

        private void FormChooseTest_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            testsTableAdapter1.FillTests(testDataSet1.Tests);
            listBox1.DataSource = testDataSet1.Tests;
            listBox1.DisplayMember = "TestName";
            listBox1.ValueMember = "idTest";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                DataRowView id = (DataRowView)listBox1.Items[listBox1.SelectedIndex];
                int idTest = Convert.ToInt32(id.Row[0]);
                FormUserTesting form = new FormUserTesting(idTest);
                form.ShowDialog();
                
            }
        }
    }
}
