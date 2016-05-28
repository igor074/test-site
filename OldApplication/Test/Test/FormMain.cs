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
    public partial class FormMain : Form
    {
        private int indexRow;

        public FormMain()
        {
            InitializeComponent();
        }

        private void типыВопросовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTipVoprosa f = new FormTipVoprosa();
            f.ShowDialog();
        }

        private void областиВопросовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOblastiVoprosa f = new FormOblastiVoprosa();
            f.ShowDialog();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 f = new Form1();
            System.Windows.Forms.DialogResult res = f.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                this.Visible = true;
                LoadData();
            }
            else
            {
                if (res == System.Windows.Forms.DialogResult.Retry)
                {
                    FormChooseType form = new FormChooseType();
                    form.ShowDialog();
                    Close();
                }
                else
                    if (res == System.Windows.Forms.DialogResult.Ignore)
                    {
                        FormCheckOlimp form = new FormCheckOlimp();
                        form.ShowDialog();
                        Close();
                    }
            }
        }

        private void LoadData()
        {
            voprosyTableAdapter1.Fill(testDataSet1.Voprosy);
            dataGridViewVoprosy.DataSource = testDataSet1.Voprosy;

            olimpiadyTableAdapter1.Fill(testDataSet1.Olimpiady);
            dataGridViewOlimp.DataSource = testDataSet1.Olimpiady;
        }

        private void учебныеЗаведенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUchebnyeZavedenija f = new FormUchebnyeZavedenija();
            f.ShowDialog();
        }

        private void ученикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUcheniki f = new FormUcheniki();
            f.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridViewVoprosy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                
        }

        private void dataGridViewVoprosy_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void dataGridViewVoprosy_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                indexRow = dataGridViewVoprosy.HitTest(e.X, e.Y).RowIndex;
                dataGridViewVoprosy.ClearSelection();
                dataGridViewVoprosy.Rows[indexRow].Selected = true;
            }
        }

        private void изменитьВопросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = dataGridViewVoprosy.Rows[indexRow].Cells[3].Value.ToString();
            string idVoprosa = dataGridViewVoprosy.Rows[indexRow].Cells[6].Value.ToString();
            string type = dataGridViewVoprosy.Rows[indexRow].Cells[0].Value.ToString();
            string oblast = dataGridViewVoprosy.Rows[indexRow].Cells[1].Value.ToString();
            string ball = dataGridViewVoprosy.Rows[indexRow].Cells[4].Value.ToString();
            string path = dataGridViewVoprosy.Rows[indexRow].Cells[5].Value.ToString();
            FormSozdanieVoprosa form = new FormSozdanieVoprosa('u', idVoprosa, text,type, oblast, ball, path);
            form.ShowDialog();
            LoadData();
        }

        private void тестыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTests form = new FormTests();
            form.ShowDialog();
        }

        private void удалитьВопросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridViewVoprosy.Rows[indexRow].Cells[6].Value);
                int idType = Convert.ToInt32(dataGridViewVoprosy.Rows[indexRow].Cells[0].Value);
                int idOblast = Convert.ToInt32(dataGridViewVoprosy.Rows[indexRow].Cells[1].Value);
                voprosyTableAdapter1.Delete(idType, idOblast, id);
                LoadData();
                MessageBox.Show("Вопрос удалён!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void добавитьВопросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSozdanieVoprosa form = new FormSozdanieVoprosa();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            voprosyTableAdapter1.Fill(testDataSet1.Voprosy);
            dataGridViewVoprosy.DataSource = testDataSet1.Voprosy;

            olimpiadyTableAdapter1.Fill(testDataSet1.Olimpiady);
            dataGridViewOlimp.DataSource = testDataSet1.Olimpiady;
        }

        private void регистрацияПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddUser f = new FormAddUser();
            f.ShowDialog();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Тестовая программа ЗЕБРА. Предназначена для проверки знаний учеников различными методами. Проведение тестирования, проведение тестирования аддитивным методом и прохождение олимпиады.");
        }

      

        private void dataGridViewOlimp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                indexRow = dataGridViewOlimp.HitTest(e.X, e.Y).RowIndex;
                dataGridViewOlimp.ClearSelection();
                dataGridViewOlimp.Rows[indexRow].Selected = true;
            }
        }
      
        private void dataGridViewOlimp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void добавитьВопросToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormOlimpiady form = new FormOlimpiady();
            form.ShowDialog();
        }

        private void dataGridViewVoprosy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
