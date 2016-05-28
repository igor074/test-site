using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IQuestionLib;

namespace ChroniceSequence
{
    public partial class ChroniceSequence: UserControl, IQuestion
    {
        private TypeQuestion _type = TypeQuestion.ChroniceSequence;

        public TypeQuestion Type
        {
            get { return TypeQuestion.ChroniceSequence; }
            set { _type = value; }
        }

        public ChroniceSequence()
        {
            InitializeComponent();
            n = 3;

           dataGridView1.ColumnCount=2;
           dataGridView1.RowCount = n;
           //dataGridView2.ColumnCount = 2;
           //dataGridView2.RowCount = 4;
        }

        private int n;
        private DataGridViewRow[] dgv;
        private string[] one;
        private string[] two;

        private string[] right;

        Color colRow = new Color();
        Random r = new Random();
        
        private void UserControl1_Load(object sender, EventArgs e)
        {
            //for (int i = 0; i < dataGridView1.RowCount; i++)
            //{
            //    Color col = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
            //    dataGridView1[0, i].Style.BackColor = col;
            //}
           //this.sootvetstvijaTableAdapter.Fill(this.databaseSootvDataSet1.sootvetstvija);
        }

        [Category("Text"), Description("Изменение текста вопроса")]
        public string Text_Question
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        [Category("Text"), Description("Изменение 1 столбца")]
        public string [] oneColumn
        {
            get { return one; }
            set { one = value; }
        }

        private void SetOne()
        {
            if (two != null)
                if (two.GetLength(0) > 0)
                {
                    dataGridView1.RowCount = two.GetLength(0);
                }
        }

        [Category("Text"), Description("Изменение 2 столбца")]
        public string[] twoColumn
        {
            get { return two; }
            set { two = value; }
        }

        private void SetTwo()
        {
            if (two != null)
                if (two.GetLength(0) > 0)
                {
                    int[] mas = Enumerable.Range(1, two.GetLength(0)).RandomShuffle().ToArray();
                    for (int i = 0; i < two.GetLength(0); i++)
                    {
                        dataGridView1.Rows[i].Cells[1].Value = two[mas[i]-1];
                    }
                }
        }

        [Category("Size"), Description("Изменение количества строк")]
        public int Row_count
        {
            get { return n; }
            set { n = value; ControlRow(value); }
        }

        private void ControlRow(int count)
        {
            //dataGridView1.Rows.RemoveAt(count);// удаляет по индексу
            dataGridView1.Rows.Clear();
            dgv = new DataGridViewRow[count];
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Resizable = DataGridViewTriState.False;
            dataGridView1.Rows.Add(count);
            SetOne();
            SetTwo();
        }
        
        //Перерисовать себя при изменении свойств
        private void OnChangeProperties()
        {
            Invalidate();
        }
        
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView1[1, e.RowIndex].Style.BackColor = colRow;
            }
            if (e.Button == MouseButtons.Left)
            {
                colRow = dataGridView1[0, e.RowIndex].Style.BackColor;
            }
        }

        public void SetData(List<Otvety> list)
        {
            if (list != null)
            {
                right = list[0].textOtveta.Split('|');
                two = list[0].textOtveta.Split('|');
                SetOne();
                SetTwo();
            }
        }

        public bool GetAnswer()
        {
            try
            {
                string[] res = new string[two.GetLength(0)];
                for (int i = 0; i < two.GetLength(0); i++)
                {
                    res[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value) - 1] = dataGridView1.Rows[i].Cells[1].Value.ToString();
                }
                bool b = Enumerable.SequenceEqual(res, right);
                return b;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public UserControl ControlQuestion
        {
            get { return new ChroniceSequence(); }
        }
    }
}
