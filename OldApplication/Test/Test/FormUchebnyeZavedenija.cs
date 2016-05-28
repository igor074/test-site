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
    public partial class FormUchebnyeZavedenija : Form
    {
        public FormUchebnyeZavedenija()
        {
            InitializeComponent();
        }

        private void FormUchebnyeZavedenija_Load(object sender, EventArgs e)
        {
            uchebnyeZavedenijaTableAdapter1.Fill(testDataSet1.UchebnyeZavedenija);
            dataGridView1.DataSource = testDataSet1.UchebnyeZavedenija;
            dataGridView1.Columns["id_UchZavedenija"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestDataSet.UchebnyeZavedenijaRow row = testDataSet1.UchebnyeZavedenija.NewUchebnyeZavedenijaRow();
            row.adres = textBox3.Text;
            row.mestopolozhenie = textBox2.Text;
            row.nameUchZavedenija = textBox1.Text;
            testDataSet1.UchebnyeZavedenija.AddUchebnyeZavedenijaRow(row);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uchebnyeZavedenijaTableAdapter1.Update(testDataSet1.UchebnyeZavedenija);
        }
    }
}
