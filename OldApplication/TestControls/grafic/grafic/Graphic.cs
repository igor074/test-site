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

namespace Graphic
{
    public partial class Graphic: UserControl, IQuestion
    {
        public Graphic()
        {
            InitializeComponent();
        }

        private bool right;

        private TypeQuestion _type = TypeQuestion.Graphic;

        public TypeQuestion Type
        {
          get { return TypeQuestion.Graphic; }
          set { _type = value; }
        }
        private Int32? FindNearestPointIndex(List<Point> points, Point point)
        {
            if ((points == null || (points.Count == 0)))
                return null;

            //Func<Point, Point, Double> getLength = (p1, p2) => Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2)); // C^2 = A^2 + B^2
            //List<Point> results = points.Select((p,i) => new { Point = p, Length = getLength(p, point), Index = i }).ToList();
            //Int32 minLength = results.Min(i => i.Length);

            //return results.First(i => (i.Length == minLength)).Index;
            return 0;
        }

        public void SetData(List<Otvety> list)
        {
            if (list != null)
            {
                label1.Text = list[0].textOtveta;
                if (list.Count > 4)
                {
                    pictureBox1.Image = new Bitmap(list[1].textOtveta);
                    pictureBox1.Tag = list[1].isWright;
                    pictureBox2.Image = new Bitmap(list[2].textOtveta);
                    pictureBox2.Tag = list[2].isWright;
                    pictureBox3.Image = new Bitmap(list[3].textOtveta);
                    pictureBox3.Tag = list[3].isWright;
                    pictureBox4.Image = new Bitmap(list[4].textOtveta);
                    pictureBox4.Tag = list[4].isWright;
                }
            }
        }

        public bool GetAnswer()
        {
            return right;
        }


        public UserControl ControlQuestion
        {
            get { return new Graphic(); }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            right = (bool)pictureBox1.Tag;
            pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            right = (bool)pictureBox2.Tag;
            pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            right = (bool)pictureBox3.Tag;
            pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            right = (bool)pictureBox4.Tag;
            pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }
    }
}
