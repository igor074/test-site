using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IQuestionLib;

namespace FullAnswer
{
    public partial class FullAnswer: UserControl, IQuestion
    {
        //protected override void OnPaintAdornments(PaintEventArgs pe)
        //{
        //    base.OnPaintAdornments(pe);
        //    string text = "© Чемис";
        //    pe.Graphics.DrawString(text, this.Control.Font, new SolidBrush(Color.Pink), 0,
        //        this.Control.Height - (int)pe.Graphics.MeasureString(text, this.Control.Font).Height - 3);
        //}
        private TypeQuestion _type = TypeQuestion.FullAnswer;

        public TypeQuestion Type
        {
            get { return TypeQuestion.FullAnswer; }
            set { _type = value; }
        }
        public FullAnswer()
        {
            InitializeComponent();
        }

        [Category("Text"), Description("Изменение текста вопроса")]
        public string Text_Question
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }


        public void SetData(List<Otvety> list)
        {
            textBox2.Text = list[0].textOtveta;
        }

        public bool GetAnswer()
        {
            return false;
        }


        public UserControl ControlQuestion
        {
            get { return new FullAnswer(); }
        }
    }
}
