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
    public partial class FormAddTest : Form
    {
        public FormAddTest()
        {
            InitializeComponent();
        }

        private void FormAddTest_Load(object sender, EventArgs e)
        {
            voprosyTableAdapter1.Fill(testDataSet1.Voprosy);
            listBox1.DataSource = testDataSet1.Voprosy;
            listBox1.DisplayMember = "textVoprosa";
            listBox1.ValueMember = "id_Voprosa";

            listBox2.DisplayMember = "textVoprosa";
            listBox2.ValueMember = "id_Voprosa";
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBox1.IndexFromPoint(e.X, e.Y);
            listBox2.Items.Add(listBox1.Items[index]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    TestDataSet.TestsRow row = testDataSet1.Tests.NewTestsRow();
                    row.TestName = textBox1.Text;
                    testDataSet1.Tests.AddTestsRow(row);
                    testsTableAdapter1.Update(testDataSet1.Tests);

                    int id = (int)testsTableAdapter1.LastInsertId();

                    for (int i = 0; i < listBox2.Items.Count; i++)
                    {
                        TestDataSet.TestsQuestionsRow row1 = testDataSet1.TestsQuestions.NewTestsQuestionsRow();
                        DataRowView row2 = (DataRowView)listBox2.Items[i];
                        row1.id_Voprosa = Convert.ToInt32(row2[6]);
                        row1.idTest = id;
                        testDataSet1.TestsQuestions.AddTestsQuestionsRow(row1);
                        testsQuestionsTableAdapter1.Update(testDataSet1.TestsQuestions);
                    }
                    MessageBox.Show("Тест добавлен!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
