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
    public partial class FormTipVoprosa : Form
    {
        public FormTipVoprosa()
        {
            InitializeComponent();
        }

        private void FormTipVoprosa_Load(object sender, EventArgs e)
        {
            this.tipVoprosaTableAdapter1.Fill(this.testDataSet1.TipVoprosa);
            dataGridView1.DataSource = testDataSet1.TipVoprosa;
            dataGridView1.Columns["id_tipVoprosa"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tipVoprosaTableAdapter1.Update(testDataSet1.TipVoprosa);
        }
    }
}
