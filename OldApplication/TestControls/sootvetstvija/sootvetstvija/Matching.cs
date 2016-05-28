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

namespace Matching
{
    public partial class Matching: UserControl, IQuestion
    {
        private TypeQuestion _type = TypeQuestion.Matching;

        public TypeQuestion Type
        {
            get { return TypeQuestion.Matching; }
            set { _type = value; }
        }

        public Matching()
        {
            InitializeComponent();
            n = 3;

           dataGridView1.ColumnCount=2;
           dataGridView1.RowCount = n;
           _answ = new Dictionary<int, int>();
        }

        private int n;
        private DataGridViewRow[] dgv;
        private string[] one;
        private string[] two;
        private string[] right;

        private Dictionary<int, int> _answ;

        Color colRow = new Color();
        Random r = new Random();
        
        private void UserControl1_Load(object sender, EventArgs e)
        {
            SetColors();
        }

        private void SetColors()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                Color col = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
                dataGridView1[0, i].Style.BackColor = col;
            }
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
            if (one != null)
                if (one.GetLength(0) > 0)
                {
                    dataGridView1.RowCount = one.GetLength(0);
                    SetColors();
                    for (int i = 0; i < one.GetLength(0); i++)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = one[i];
                    }
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
                        dataGridView1.Rows[i].Cells[1].Value = two[mas[i] - 1];
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
            // dataGridView1.ColumnHeadersVisible = true;// добавляет названия
            dataGridView1.Rows.Add(count);
            SetOne();
            SetTwo();

            //for (int i = 0; i < dataGridView1.RowCount; i++)
            //{
            //    Color col = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
            //    dataGridView1[0, i].Style.BackColor = col;
            //}
        }
        
        //Перерисовать себя при изменении свойств
        private void OnChangeProperties()
        {
            Invalidate();
        }
     
        private void UserControl1_Click(object sender, EventArgs e)
        {
            
        }
        private int rowIndex;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView1[1, e.RowIndex].Style.BackColor = colRow;
                _answ.Add(rowIndex, e.RowIndex);
            }
            if (e.Button == MouseButtons.Left)
            {
                colRow = dataGridView1[0, e.RowIndex].Style.BackColor;
                rowIndex = e.RowIndex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void sootvetstvijaBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        public void SetData(List<Otvety> list)
        {
            if (list != null)
            {
                one = list[0].textOtveta.Split('|');
                two = list[1].textOtveta.Split('|');
                right = list[1].textOtveta.Split('|');
                SetOne();
                SetTwo();
            }
        }

        public bool GetAnswer()
        {
            try
            {
                string[] res = new string[dataGridView1.RowCount];
                foreach (int i in _answ.Keys)
                {
                    res[i] = dataGridView1[1, _answ[i]].Value.ToString();
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
            get { return new Matching(); }
        }

        private void ResetColor()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1[1, i].Style.BackColor = Color.WhiteSmoke;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _answ.Clear();
            ResetColor();
        }
    }
}
