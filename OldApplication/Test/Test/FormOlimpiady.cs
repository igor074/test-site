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
    public partial class FormOlimpiady : Form
    {
        public FormOlimpiady()
        {
            InitializeComponent();
        }

        private void FormOlimpiady_Load(object sender, EventArgs e)
        {
            olimpiadyTableAdapter1.Fill(testDataSet1.Olimpiady);
            dataGridView1.DataSource = testDataSet1.Olimpiady;
            dataGridView1.Columns["id_Olimpiady"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestDataSet.OlimpiadyRow row = testDataSet1.Olimpiady.NewOlimpiadyRow();
            row.predmet = textBox1.Text;
            row.sostojanie = checkBox1.Checked;
            row.status = textBox2.Text;
            testDataSet1.Olimpiady.AddOlimpiadyRow(row);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            olimpiadyTableAdapter1.Update(testDataSet1.Olimpiady);
        }
    }
}
