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
    public partial class FormOblastiVoprosa : Form
    {
        public FormOblastiVoprosa()
        {
            InitializeComponent();
        }

        private void FormOblastiVoprosa_Load(object sender, EventArgs e)
        {
            oblastiVoprosaTableAdapter1.Fill(testDataSet1.OblastiVoprosa);
            dataGridView1.DataSource = testDataSet1.OblastiVoprosa;
            dataGridView1.Columns["id_oblastVoprosa"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oblastiVoprosaTableAdapter1.Update(testDataSet1.OblastiVoprosa);
        }
    }
}
