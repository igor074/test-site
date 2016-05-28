using System;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bolee_1
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        PictureBox pbx = new PictureBox();
        private int countCB;

        [Category("Display"), Description("Отображение картинки")]
        public bool Picture
        {
            get { return this.pbx.Visible; }
            set { this.pbx.Visible = value; }
        }

        [Category("Count"), Description("Изменить количество radioButton")]
        public int CB
        {
            get { return countCB; }
            set { countCB = value; ControlCB(value); }
        }
        
        private void ControlCB(int count)
        {
            Controls.Clear();
            if (count < 9)
            {
                CheckBox[] rb = new CheckBox[count];
                for (int i = 0; i < count; i++)
                {
                    TextBox tBox = new TextBox();
                    tBox.Location = new System.Drawing.Point(20, 5);
                    tBox.Size = new System.Drawing.Size(400, 10);
                    tBox.Name = "textBox1";
                    tBox.Text = "Вопрос";
                    Controls.Add(tBox);
                    Bitmap bmp1 = new Bitmap("C:/Users/Olja/Desktop/1.png");
                    pbx.Name = "pictureBox1";
                    pbx.Location = new System.Drawing.Point(200, 70);
                    pbx.Size = new System.Drawing.Size(200, 200);
                    pbx.Image = bmp1;
                    Controls.Add(pbx);

                    rb[i] = new System.Windows.Forms.CheckBox();
                    rb[i].Location = new System.Drawing.Point(20, 80 + i * 30);
                    rb[i].Name = "checkBox " + (i + 1).ToString();
                    rb[i].Size = new System.Drawing.Size(100, 30);
                    rb[i].TabIndex = i;
                    rb[i].Text = "Вариант ответа " + (i + 1).ToString();
                    Controls.Add(rb[i]);

                    if (pbx.Visible == false)
                    {
                        Button but = new Button();
                        but.Location = new System.Drawing.Point(300, 90 + count * 30);
                        but.Name = "button2";
                        rb[i].Size = new System.Drawing.Size(500, 30);
                        but.Text = "Далее";
                        Controls.Add(but);
                    }
                    else
                    {
                        Button but = new Button();
                        but.Location = new System.Drawing.Point(320, pbx.Size.Height + pbx.Location.Y + 20);
                        but.Name = "button2";
                        rb[i].Size = new System.Drawing.Size(500, 30);
                        but.Text = "Далее";
                        Controls.Add(but);
                    }


                }

            }
            else { MessageBox.Show("Превышен лимит вариантов"); }
            //if (count > 9 || count < 18)
            //{

            //    CheckBox[] rb = new CheckBox[count];
            //    for (int i = 0; i < count; i++)
            //    {

            //        rb[i] = new System.Windows.Forms.CheckBox();
            //        rb[i].Location = new System.Drawing.Point(30, 80 + i * 30);
            //        rb[i].Name = "checkBox " + (i + 1).ToString();
            //        rb[i].Location = new System.Drawing.Point(200, 80 + i * 30);
            //        rb[i].Name = "checkBox " + (i + 8).ToString();
            //        rb[i].Size = new System.Drawing.Size(300, 30);
            //        rb[i].TabIndex = i;
            //        rb[i].Text = "Вариант ответа " + (i + 8).ToString();
            //        Controls.Add(rb[i]);
            //        // Array.Clear(rb, 0, count);
            //    }
            //}
        }


        
 
        //Перерисовать себя при изменении свойств
        private void OnChangeProperties()
        {
            Invalidate();
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
