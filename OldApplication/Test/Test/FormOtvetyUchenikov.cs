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
    public partial class FormOtvetyUchenikov : Form
    {
        public FormOtvetyUchenikov()
        {
            InitializeComponent();
        }

        private void FormOtvetyUchenikov_Load(object sender, EventArgs e)
        {
            otvetyUchenikaTableAdapter1.Fill(testDataSet1.OtvetyUchenika);
            dataGridView1.DataSource = testDataSet1.OtvetyUchenika;

            olimpiadyTableAdapter1.Fill(testDataSet1.Olimpiady);
            comboBox1.DataSource = testDataSet1.Olimpiady;
            comboBox1.DisplayMember = "predmet";
            comboBox1.ValueMember = "id_Olimpiady";

            voprosyTableAdapter1.Fill(testDataSet1.Voprosy);
            comboBox2.DataSource = testDataSet1.Voprosy;
            comboBox2.DisplayMember = "textVoprosa";
            comboBox2.ValueMember = "id_Voprosa";

            uchenikiTableAdapter1.Fill(testDataSet1.Ucheniki);
            comboBox3.DataSource = testDataSet1.Ucheniki;
            //comboBox3.DisplayMember = "";
            comboBox3.ValueMember = "id_Uchenika";
        }

        private void comboBox3_Format(object sender, ListControlConvertEventArgs e)
        {
            string first = ((DataRowView)e.ListItem)["ferstname"].ToString();
            string last = ((DataRowView)e.ListItem)["name"].ToString();
            e.Value = last + " " + first;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestDataSet.OtvetyRow row = testDataSet1.Otvety.NewOtvetyRow();
            row.textOtveta = textBox1.Text;
            testDataSet1.Otvety.AddOtvetyRow(row);
            otvetyTableAdapter1.Update(testDataSet1.Otvety);
            int idOtveta = (int)otvetyTableAdapter1.LastInsertId();

            TestDataSet.OtvetyUchenikaRow row1 = testDataSet1.OtvetyUchenika.NewOtvetyUchenikaRow();
            row1.id_Olimpiady = Convert.ToInt32(comboBox1.SelectedValue);
            row1.id_Otveta = idOtveta;
            row1.id_Uchenika = Convert.ToInt32(comboBox3.SelectedValue);
            row1.id_Voprosa = Convert.ToInt32(comboBox2.SelectedValue);
            row1.otvetUchenika = textBox1.Text;
            testDataSet1.OtvetyUchenika.AddOtvetyUchenikaRow(row1);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            otvetyUchenikaTableAdapter1.Update(testDataSet1.OtvetyUchenika);
        }
    }
}
