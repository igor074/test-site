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

namespace LogicRelation
{
    public partial class LogicRelation: UserControl, IQuestion
    {
        private TypeQuestion _type = TypeQuestion.LogicRelation;

        public TypeQuestion Type
        {
            get { return TypeQuestion.LogicRelation; }
            set { _type = value; }
        }

        public LogicRelation()
        {
            InitializeComponent();
            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = 1;
            dataGridView2.RowCount = n;
            dataGridView2.ColumnCount = 1;
            g = this.CreateGraphics();
        }
        int n=5;
        int Xn;
        int Yn;
        int Xp;
        int Yp;
        int fl = 0;
        Graphics g;
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            fl = 1;
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            fl = 2;
        }

        private void UserControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (fl == 1)
            {
                Xn = e.X;
                Yn = e.Y;
            }
            if (fl == 2)
            {
                Pen p = new Pen(Color.Black);
                Xp = e.X;
                Yp = e.Y;

                g.DrawLine(p, Xn, Yn, Xp, Yp);
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
        }

        public void SetData(List<Otvety> list)
        {
            if (list != null)
            {
                string[] t1 = list[0].textOtveta.Split('|');
                string[] t2 = list[1].textOtveta.Split('|');

                for (int i = 0; i < 5; i++)
                {
                    dataGridView1[0, i].Value = t1[i];
                }
                List<int> rNum = Enumerable.Range(1, 5).RandomShuffle().ToList();
                int j = 0;
                foreach (int i in rNum)
                {
                    dataGridView2[0, j].Value = t2[i-1];
                    j++;
                }
            }
        }

        public bool GetAnswer()
        {
            throw new NotImplementedException();
        }


        public UserControl ControlQuestion
        {
            get { return new LogicRelation(); }
        }
    }
}
