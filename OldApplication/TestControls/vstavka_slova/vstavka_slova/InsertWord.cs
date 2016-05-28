using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using IQuestionLib;

namespace InsertWord
{
    public partial class InsertWord: UserControl, IQuestion
    {
        private TypeQuestion _type = TypeQuestion.InsertWords;
        private string right;
        private FlowLayoutPanel flp;
        public TypeQuestion Type
        {
            get { return TypeQuestion.InsertWords; }
            set { _type = value; }
        }

        public InsertWord()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            //InitializeComponent();
        }

        //[Category("Text"), Description("Изменение текста вопроса")]
        //public string Text_Question
        //{
        //    get { return label1.Text; }
        //    set { label1.Text = value; }
        //}

         private void openXML()
        {
            //XmlTextReader reader = new XmlTextReader("test.xml");// читаем файл
            //XmlNodeType type; // тип
            //while (reader.Read())
            //{
            //    type = reader.NodeType; // читать тип узла
            //    if (type == XmlNodeType.Element)
            //    {
            //        if (reader.Name == "text")
            //        {
            //            reader.Read();
            //            label1.Text = reader.Value;
            //        }
            //    }
            //}
            //reader.Close();
        }
         private void createXML()
         {
             string pathToXml = "C:/Users/solny_000/Documents/Visual Studio 2012/Projects/vstavka_slova/vstavka_slova/test.xml";
             XmlTextWriter textWritter = new XmlTextWriter(pathToXml, Encoding.Default);
             textWritter.WriteStartDocument();
             textWritter.WriteStartElement("test");
             textWritter.WriteEndElement();
             textWritter.Close();
             XmlDocument document = new XmlDocument();// для занесения данных
             document.Load(pathToXml);//загружаем файл
             //создаем запись
             XmlNode element = document.CreateElement("question");
             document.DocumentElement.AppendChild(element);//указываем родителя
             XmlAttribute attribute = document.CreateAttribute("number"); // создаем атрибут
             attribute.Value = "1";
             element.Attributes.Append(attribute);// добавляем атрибут

             XmlNode text = document.CreateElement("text");//имя
             document.DocumentElement.AppendChild(text);
             attribute = document.CreateAttribute("number"); // создаем атрибут
             attribute.Value = "1";
             text.Attributes.Append(attribute);// добавляем атрибут
             text.InnerText = "Вопрос";//значение
             element.AppendChild(text);// указываем кому принадлежит
            
             XmlNode right = document.CreateElement("right");
             document.DocumentElement.AppendChild(right);//указываем родителя
             right.InnerText = "1941";
             element.AppendChild(right);
             document.Save(pathToXml);
         }

         private void button1_Click(object sender, EventArgs e)
         {
             //label3.Text = "";
             //XmlTextReader reader = new XmlTextReader("test.xml");// читаем файл
             //XmlNodeType type; // тип
             //while (reader.Read())
             //{
             //    type = reader.NodeType; // читать тип узла
             //    if (type == XmlNodeType.Element)
             //    {
             //        if (reader.Name == "right")
             //        {  
             //           reader.Read();
             //           if (textBox1.Text == reader.Value)
             //           {
             //               int bally = 0;
             //               bally++;
             //               string a = Convert.ToString(bally);
             //               label3.Text = a;
             //           }
             //           else label3.Text = "Ответ не верный";
             //        }
                   
             //    }
             //}
         }
         //Перерисовать себя при изменении свойств
         private void OnChangeProperties()
         {
             Invalidate();
         }

         private void textBox1_TextChanged(object sender, EventArgs e)
         {
             //textBox1.Text = ((TextBox)sender).Text;
         }


         public void SetData(List<Otvety> list)
         {
             if (list != null)
             {
                 SetControls(list[0].textOtveta);
                 right = list[1].textOtveta;
             }
         }

         private void SetControls(string question)
         {
             this.Controls.Clear();
             FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel();
             flowLayoutPanel2.FlowDirection = FlowDirection.LeftToRight;
             flowLayoutPanel2.Dock = DockStyle.Fill;
             flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
             string[] temp = question.Split("$".ToArray(), StringSplitOptions.RemoveEmptyEntries);
             if (temp.GetLength(0) > 1)
             {
                 for (int i = 0; i < temp.GetLength(0); i++)
                 {
                     Label l = new Label();
                     l.Name = "Label" + i;
                     l.Text = temp[i];
                     l.AutoSize = true;
                     flowLayoutPanel2.Controls.Add(l);

                     if (i != temp.GetLength(0) - 1)
                     {
                         TextBox t = new TextBox();
                         t.Name = "textBox" + i;
                         flowLayoutPanel2.Controls.Add(t);
                     }
                 }
                 this.Controls.Add(flowLayoutPanel2);
                 flp = flowLayoutPanel2;
             }
         }

         public bool GetAnswer()
         {
             try
             {
                 string res = string.Empty;
                 foreach (Control x in flp.Controls)
                 {
                     if (x is TextBox)
                     {
                         res = ((TextBox)x).Text;
                         break;
                     }
                 }
                 return right == res;
             }
             catch (Exception)
             {
                 return false;
             }
         }


         public UserControl ControlQuestion
         {
             get { return new InsertWord(); }
         }
    }
}
