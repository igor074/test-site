using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using IQuestionLib;

namespace OneVariant
{
    public partial class OneVariant:UserControl, IQuestion
    {
        public OneVariant()
        {
            InitializeComponent();
            ControlRB(4);
            countRB = 4;
            openXML(4);
        }
        private string right;

        private TypeQuestion _type = TypeQuestion.OneVariant;
        private int countRB;
        private string[] otvet;
        private RadioButton[] rb;
        int i = 0;
        

        [Category("Count"), Description("Изменить количество radioButton")]
        public int RB
        {
            get { return countRB; }
            set { countRB = value; ControlRB(value); }
        }
        [Category("Text"), Description("Изменить текст ответа")]
        public string[] Text_Otvety
        {
            get { return otvet; }
            set { otvet = value; }
        }

        [Category("Text"), Description("Изменить текст вопроса")]
        public string Text_Question
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        
        private void SetOtvet(RadioButton[] radio)
        {
            if(otvet != null)
                if(otvet.GetLength(0) > 0)
                    for (int i = 0; i < otvet.GetLength(0) /*&& i<countRB*/; i++)
                    {
                        radio[i].Text = otvet[i];
                    }
        }
        
        private void ControlRB(int count)
        {
            this.Controls.OfType<RadioButton>().ToList().ForEach(p => this.Controls.Remove(p));
            this.Controls.OfType<Button>().ToList().ForEach(p => this.Controls.Remove(p));
            if (count < 9)
            {
                 rb = new RadioButton[count];
               
                for (i = 0; i < count; i++)
                {
                    rb[i] = new System.Windows.Forms.RadioButton();
                    rb[i].Location = new System.Drawing.Point(101, 50 + i * 30);
                    rb[i].Name = "radioButton" + (i+1).ToString();
                    rb[i].Size = new System.Drawing.Size(300, 30);
                    rb[i].TabIndex = i;
                    rb[i].Checked = false;
                    rb[i].Text = "";
                    Controls.Add(rb[i]);
                }
                SetOtvet(rb);
            }
        }

        private void createXML(int count)
        {
            string pathToXml = "C:/Users/solny_000/Documents/Visual Studio 2012/Projects/1_variant/1_variant/test.xml";
            XmlTextWriter textWritter = new XmlTextWriter(pathToXml, Encoding.UTF8);
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

            for (int i = 0; i < count; i++)
            {
                XmlNode variant = document.CreateElement("variant");
                document.DocumentElement.AppendChild(variant);//указываем родителя
                XmlAttribute attribute1 = document.CreateAttribute("number"); // создаем атрибут
                attribute1.Value = Convert.ToString(i+1);
                variant.Attributes.Append(attribute1);// добавляем атрибут
                variant.InnerText = "Вариант ответа";
                element.AppendChild(variant);
                document.Save(pathToXml);
            }
        }

        private void openXML(int count)
        {
            i = 0;
            XmlTextReader reader = new XmlTextReader("test.xml");// читаем файл
            XmlNodeType type; // тип
            List<string> temp = new List<string>();
            
            //while (reader.Read())
            //{
            //    type = reader.NodeType; // читать тип узла
            //    if (type == XmlNodeType.Element)
            //    {
            //        if (reader.Name == "text")
            //        {
            //            reader.Read();
            //            label1.Text = reader.Value;
            //            int c = Convert.ToInt32(reader.AttributeCount.ToString());
            //        }

            //        if (reader.Name == "variant" && reader.HasAttributes)
            //        {
            //            reader.Read();
            //            temp.Add(reader.Value);
            //            if (i < count)
            //            {
            //                rb[i].Text = temp[i];
            //                i++;
            //            }
            //        }
            //    }
            //}
            //reader.Close();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        //Перерисовать себя при изменении свойств
        private void OnChangeProperties()
        {
            Invalidate();
        }


        public TypeQuestion Type
        {
            get
            {
                return TypeQuestion.OneVariant;
            }
            set
            {
                _type = value;
            }
        }


        public void SetData(List<Otvety> list)
        {
            textBox1.Text = list[0].textOtveta;
            
            if (list != null)
            {
                otvet = new string[list.Count - 1];
                for (int i = 1; i < list.Count; i++)
                {
                    otvet[i - 1] = list[i].textOtveta;
                    if (list[i].isWright)
                        right = list[i].textOtveta;
                }
                ControlRB(otvet.GetLength(0));
            }
        }

        public bool GetAnswer()
        {
            try
            {
                string res = string.Empty;
                foreach (Control x in this.Controls)
                {
                    if (x is RadioButton)
                    {
                        if (((RadioButton)x).Checked)
                            res = ((RadioButton)x).Text;
                    }
                }
                return res == right;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public UserControl ControlQuestion
        {
            get { return new OneVariant(); }
        }

        private void OneVariant_Load(object sender, EventArgs e)
        {

        }
    }
}
