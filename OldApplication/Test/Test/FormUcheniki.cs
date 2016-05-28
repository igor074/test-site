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
    public partial class FormUcheniki : Form
    {
        public FormUcheniki()
        {
            InitializeComponent();
        }

        private void FormUcheniki_Load(object sender, EventArgs e)
        {
            uchenikiTableAdapter1.FillBy(testDataSet1.Ucheniki);
            dataGridView1.DataSource = testDataSet1.Ucheniki;
            dataGridView1.Columns["id_Uchenika"].Visible = false;
            //dataGridView1.Columns["id_UchZavedenija"].Visible = false;

            uchebnyeZavedenijaTableAdapter1.Fill(testDataSet1.UchebnyeZavedenija);
            comboBox1.DataSource = testDataSet1.UchebnyeZavedenija;
            comboBox1.DisplayMember = "nameUchZavedenija";
            comboBox1.ValueMember = "id_UchZavedenija";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestDataSet.UchenikiRow row = testDataSet1.Ucheniki.NewUchenikiRow();
            row.ferstname = textBox1.Text;
            row.id_UchZavedenija = Convert.ToInt32(comboBox1.SelectedValue);
            row.name = textBox2.Text;
            row.otchestvo = textBox3.Text;
            //row.nameUchZavedenija = ((DataRowView)comboBox1.SelectedItem)["nameUchZavedenija"].ToString();
            testDataSet1.Ucheniki.AddUchenikiRow(row);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uchenikiTableAdapter1.Update(testDataSet1.Ucheniki);
        }
    }
}
