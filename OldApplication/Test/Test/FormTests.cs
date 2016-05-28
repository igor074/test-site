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
    public partial class FormTests : Form
    {
        private int indexRow;

        public FormTests()
        {
            InitializeComponent();
        }

        private void FormTests_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAddTest form = new FormAddTest();
            form.ShowDialog();
            LoadData();
        }

        private void LoadData()
        {
            testsTableAdapter1.FillTests(testDataSet1.Tests);
            dataGridView1.DataSource = testDataSet1.Tests;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.Rows[indexRow].Cells[0].Value);
                testsTableAdapter1.Delete(id);
                LoadData();
                MessageBox.Show("Тест удалён!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            indexRow = e.RowIndex;
        }
    }
}
