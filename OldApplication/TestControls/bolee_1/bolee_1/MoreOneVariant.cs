using System;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IQuestionLib;

namespace MoreOneVariant
{
    public partial class MoreOneVariant : UserControl, IQuestion
    {
        private List<string> right;

        public MoreOneVariant()
        {
            InitializeComponent();
            ControlCB(6);
            countCB = 6;
            openXML(6);
            right = new List<string>();
        }

        private TypeQuestion _type = TypeQuestion.MoreOneVariant;

        public TypeQuestion Type
        {
            get { return TypeQuestion.MoreOneVariant; }
            set { _type = value; }
        }
        private int countCB;
        private string[] otvet;
        private CheckBox[] cb;

        

        [Category("Count"), Description("Изменить количество сheckBox")]
        public int CB
        {
            get { return countCB; }
            set { countCB = value; ControlCB(value); }
        }
        [Category("Text"), Description("Изменение текста вопроса")]
        public string Text_Question
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        [Category("Text"), Description("Изменить текст ответа")]
        public string[] Text_Otvety
        {
            get { return otvet; }
            set { otvet = value; } //SetOtvet();
        }
        private void SetOtvet(CheckBox[] check)
        {
            if (otvet != null)
                if (otvet.GetLength(0) > 0)
                    for (int i = 0; i < otvet.GetLength(0) && i<countCB; i++)
                    {
                        check[i].Text = otvet[i];
                    }
        }
        //public IEnumerable<Control> GetAll(Control control, Type type)
        //{
        //    var controls = control.Controls.Cast<Control>();
        //    return controls.SelectMany(ctrls => GetAll(ctrls, type)).Concat(controls).Where(c => c.GetType() == type);
        //}


        private void ControlCB(int count)
        {
            this.Controls.OfType<CheckBox>().ToList().ForEach(p => this.Controls.Remove(p));
            this.Controls.OfType<Button>().ToList().ForEach(p => this.Controls.Remove(p));
            //Controls.Clear();
            //var cntls = GetAll(this, typeof(CheckBox));
            // cntls = GetAll(this, typeof(Button));
            //foreach (Control cntrl in cntls)
            //{
            //    cntrl.Dispose();
            //}

            if (count < 9)
            {
                cb = new CheckBox[count];
                for (int i = 0; i < count; i++)
                {
                    TextBox tBox = new TextBox();
                    tBox.Location = new System.Drawing.Point(20, 5);
                    tBox.Size = new System.Drawing.Size(400, 10);
                    tBox.Name = "textBox1";
                    tBox.Text = "Вопрос";
                    Controls.Add(tBox);

                    cb[i] = new System.Windows.Forms.CheckBox();
                    cb[i].Location = new System.Drawing.Point(20, 80 + i * 30);
                    cb[i].Name = "checkBox " + (i + 1).ToString();
                    cb[i].Size = new System.Drawing.Size(100, 30);
                    cb[i].TabIndex = i;
                    cb[i].Text = "Вариант ответа " + (i + 1).ToString();
                    Controls.Add(cb[i]);

                    
                }
                SetOtvet(cb);
                createXML(count);
                openXML(count);
            }
            else { MessageBox.Show("Превышен лимит вариантов"); }
            //if (count > 9 || count < 18)
            //{

            //    CheckBox[] cb = new CheckBox[count];
            //    for (int i = 0; i < count; i++)
            //    {

            //        cb[i] = new System.Windows.Forms.CheckBox();
            //        cb[i].Location = new System.Drawing.Point(30, 80 + i * 30);
            //        cb[i].Name = "checkBox " + (i + 1).ToString();
            //        cb[i].Location = new System.Drawing.Point(200, 80 + i * 30);
            //        cb[i].Name = "checkBox " + (i + 8).ToString();
            //        cb[i].Size = new System.Drawing.Size(300, 30);
            //        cb[i].TabIndex = i;
            //        cb[i].Text = "Вариант ответа " + (i + 8).ToString();
            //        Controls.Add(cb[i]);
            //        // Array.Clear(cb, 0, count);
            //    }
            //}
        }
        
        private void createXML(int count)
        {
            string pathToXml = "C:/Users/solny_000/Documents/Visual Studio 2012/Projects/bolee_1/bolee_1/test.xml";
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

            for (int i = 0; i < count; i++)
            {
                XmlNode variant = document.CreateElement("variant");
                document.DocumentElement.AppendChild(variant);//указываем родителя
                XmlAttribute attribute1 = document.CreateAttribute("number"); // создаем атрибут
                attribute1.Value = Convert.ToString(i + 1);
                variant.Attributes.Append(attribute1);// добавляем атрибут
                variant.InnerText = "Вариант ответа";
                element.AppendChild(variant);
                document.Save(pathToXml);
            }
        }

        private void openXML(int count)
        {
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(System.IO.File.ReadAllText("test.xml"));
            //XmlTextReader reader = new XmlTextReader("XMLFile1.xml");
            //XmlNodeList question = doc.GetElementsByTagName("question");
            //foreach (XmlNode x in question)
            //{
            //    textBox1.Text = "question {0} = {1}" + x.Attributes[0].Name + x.Attributes[0].Value;
            //    foreach (XmlNode xc in x.ChildNodes)
            //    {
            //        textBox1.Text = xc.Name + xc.InnerText;
            //        for (int i = 0; i < count; i++)
            //        {
            //            textBox1.Text = xc.Name+xc.InnerText;
            //            CheckBox[] cb = new CheckBox[count];
            //           // cb[i].Text = Convert.ToString("\t{0} : {1}" + xc.Name + xc.InnerText);
            //        }
            //    }
            //    doc.Save("doc.xml");
            //}
            //----------------------------------------------------------------------------
            //XmlTextReader reader = new XmlTextReader("test.xml");// читаем файл
            //XmlNodeType type; // тип
            //List<string> temp=new List<string>();
            //int i=0;
            //while (reader.Read())
            //{
            //    type = reader.NodeType; // читать тип узла
            //    if (type == XmlNodeType.Element)
            //    {
            //        if (reader.Name == "text")
            //        {
            //            reader.Read();
            //            textBox1.Text = reader.Value;
            //            int c = Convert.ToInt32(reader.AttributeCount.ToString());
            //        }

            //        if (reader.Name == "variant" && reader.HasAttributes)
            //        {
            //            reader.Read();
            //            temp.Add(reader.Value);
            //            if (i < count)
            //            {
            //                cb[i].Text = temp[i];
            //                i++;
            //            }
            //        }
            //    }
            //}
            //reader.Close();
        }
        //Перерисовать себя при изменении свойств
        private void OnChangeProperties()
        {
            Invalidate();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

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
                        right.Add(list[i].textOtveta);
                }
                ControlCB(otvet.GetLength(0));
            }
        }

        public bool GetAnswer()
        {
            try
            {
                List<string> res = new List<string>();
                foreach (Control x in this.Controls)
                {
                    if (x is CheckBox)
                    {
                        if (((CheckBox)x).Checked)
                        {
                            res.Add(((CheckBox)x).Text);
                        }
                    }
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
            get { return new MoreOneVariant(); }
        }
    }
}
