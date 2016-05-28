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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Admin")
                if (comboBox1.SelectedValue.ToString() == textBox1.Text)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
                else
                { }
            else
            {
                if (comboBox1.Text == "User")
                {
                    if (comboBox1.SelectedValue.ToString() == textBox1.Text)
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.Retry;
                        Close();
                    }
                }
            }
            if (comboBox1.Text == "Teacher")
            {
                if (comboBox1.SelectedValue.ToString() == textBox1.Text)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Ignore;
                    Close();
                }
                else
                { }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                usersTableAdapter1.Fill(testDataSet1.Users);
                comboBox1.DataSource = testDataSet1.Users;
                comboBox1.DisplayMember = "UserName";
                comboBox1.ValueMember = "UserPassword";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                Close();
            }
        }
    }
}
