using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IQuestionLib;
using Test.PanelsCreateQuestion;

namespace Test
{
    public partial class FormSozdanieVoprosa : Form
    {
        private List<int> _otvetyId;
        LoadAssembles lo;
        char _act;
        private UserControl _uc;
        private IQuestionData _questionPanel;
        private string _question;
        private string _id;
        private string _typeQuestion;
        private string _oblast;
        private string _ball;
        private string _path;
        public FormSozdanieVoprosa()
        {
            InitializeComponent();
            _otvetyId = new List<int>();
            lo = new LoadAssembles(Application.StartupPath);
            lo.Load();
        }

        public FormSozdanieVoprosa(char act,string id, string question, string typeQuestion, string oblast, string ball, string path)
        {
            InitializeComponent();
            _act = act;
            _question = question;
            _id = id;
            _typeQuestion = typeQuestion;
            _oblast = oblast;
            _ball = ball;
            _path = path;
            if (act == 'u')
            {
                button2.Text = "Изменить вопрос";
                this.Text = "Изменить вопрос";
            }
            _otvetyId = new List<int>();
            lo = new LoadAssembles(Application.StartupPath);
            lo.Load();
        }

        private void sozdanieVoprosa_Load(object sender, EventArgs e)
        {
            try
            {
                this.tipVoprosaTableAdapter1.Fill(this.testDataSet1.TipVoprosa);

                comboBox1.DataSource = this.testDataSet1.TipVoprosa;
                comboBox1.ValueMember = "id_tipVoprosa";
                comboBox1.DisplayMember = "nameTipa";

                this.oblastiVoprosaTableAdapter1.Fill(this.testDataSet1.OblastiVoprosa);

                comboBox2.DataSource = this.testDataSet1.OblastiVoprosa;
                comboBox2.ValueMember = "id_oblastVoprosa";
                comboBox2.DisplayMember = "razdelVoprosa";
                if (_act == 'u')
                {
                    comboBox1.SelectedValue = _typeQuestion;
                    comboBox2.SelectedValue = _oblast;
                    textBox3.Text = _ball;
                    textBox4.Text = _path;

                    TestDataSet.OtvetyDataTable table = new TestDataSet.OtvetyDataTable();
                    otvetyTableAdapter1.FillByOtvety(table, Convert.ToInt32(_id));

                    List<Otvety> otv = new List<Otvety>();
                    Otvety o = new Otvety();
                    o.textOtveta = _question;
                    otv.Add(o);
                    otv.AddRange(ConvertDataTable.GetOtvety(table).ToArray());
                    for (int j = 1; j < otv.Count; j++)
                    {
                        bool? b = otvety_naVoprosyTableAdapter1.IsRightAnswer(Convert.ToInt32(otv[j].idOtveta));
                        otv[j].isWright = (bool)b;
                    }

                    _questionPanel.SetData(otv);
                }
            }
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_act != 'u')
            {
                try
                {
                    TestDataSet.VoprosyRow row = testDataSet1.Voprosy.NewVoprosyRow();
                    row.bally_zaVopros = Convert.ToInt32(textBox3.Text);
                    row.id_oblastVoprosa = Convert.ToInt32(comboBox2.SelectedValue);
                    row.id_tipVoprosa = Convert.ToInt32(comboBox1.SelectedValue);
                    row.izobrazhenie = textBox4.Text;
                    row.slozhnostVoprosa = Convert.ToInt32(numericUpDown1.Value);
                    List<Otvety> _otvety = _questionPanel.GetData();
                    row.textVoprosa = _otvety[0].textOtveta;

                    testDataSet1.Voprosy.AddVoprosyRow(row);
                    voprosyTableAdapter1.Update(testDataSet1.Voprosy);
                    int id = (int)voprosyTableAdapter1.LastInsertId();
                    testDataSet1.AcceptChanges();

                    //вставка ответов
                    for (int i = 1; i < _otvety.Count; i++)
                    {
                        TestDataSet.OtvetyRow row1 = testDataSet1.Otvety.NewOtvetyRow();
                        row1.textOtveta = _otvety[i].textOtveta;
                        testDataSet1.Otvety.AddOtvetyRow(row1);
                        otvetyTableAdapter1.Update(testDataSet1.Otvety);

                        int idOtveta = (int)otvetyTableAdapter1.LastInsertId();

                        TestDataSet.Otvety_naVoprosyRow row2 = testDataSet1.Otvety_naVoprosy.NewOtvety_naVoprosyRow();
                        row2.id_Otveta = idOtveta;
                        row2.id_Voprosa = id;
                        row2.rightOtvet = _otvety[i].isWright;
                        testDataSet1.Otvety_naVoprosy.AddOtvety_naVoprosyRow(row2);
                        otvety_naVoprosyTableAdapter1.Update(testDataSet1.Otvety_naVoprosy);
                    }

                    MessageBox.Show("Вопрос успешно добавлен!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            splitContainer2.Panel2.Controls.Clear();
            int i = comboBox1.SelectedIndex;
            TypeQuestion type = (TypeQuestion)i;
            switch (type)
            {
                case TypeQuestion.ChroniceSequence:
                    PanelChronice p9 = new PanelChronice();
                    p9.Dock = DockStyle.Fill;
                    p9.OnChangedProperty += OnChangedProperty;
                    splitContainer2.Panel2.Controls.Add(p9);
                    _questionPanel = p9;
                    break;
                case TypeQuestion.Compare:
                    PanelCompare p1 = new PanelCompare();
                    p1.Dock = DockStyle.Fill;
                    p1.OnChangedProperty += OnChangedProperty;
                    splitContainer2.Panel2.Controls.Add(p1);
                    _questionPanel = p1;
                    break;
                case TypeQuestion.FullAnswer:
                    PanelFullAnswer p2 = new PanelFullAnswer();
                    p2.Dock = DockStyle.Fill;
                    p2.OnChangedProperty += OnChangedProperty;
                    splitContainer2.Panel2.Controls.Add(p2);
                    _questionPanel = p2;
                    break;
                case TypeQuestion.Graphic:
                    PanelGraphic p3 = new PanelGraphic();
                    p3.Dock = DockStyle.Fill;
                    p3.OnChangedProperty += OnChangedProperty;
                    splitContainer2.Panel2.Controls.Add(p3);
                    _questionPanel = p3;
                    break;
                case TypeQuestion.InsertWords:
                    PanelInsertWord p4 = new PanelInsertWord();
                    p4.Dock = DockStyle.Fill;
                    p4.OnChangedProperty += OnChangedProperty;
                    splitContainer2.Panel2.Controls.Add(p4);
                    _questionPanel = p4;
                    break;
                case TypeQuestion.LogicRelation:
                    PanelLogicRelation p5 = new PanelLogicRelation();
                    p5.Dock = DockStyle.Fill;
                    p5.OnChangedProperty += OnChangedProperty;
                    splitContainer2.Panel2.Controls.Add(p5);
                    _questionPanel = p5;
                    break;
                case TypeQuestion.Matching:
                    PanelMatching p6 = new PanelMatching();
                    p6.Dock = DockStyle.Fill;
                    p6.OnChangedProperty += OnChangedProperty;
                    splitContainer2.Panel2.Controls.Add(p6);
                    _questionPanel = p6;
                    break;
                case TypeQuestion.MoreOneVariant:
                    PanelOneVariant p7 = new PanelOneVariant();
                    p7.Dock = DockStyle.Fill;
                    p7.OnChangedProperty += OnChangedProperty;
                    splitContainer2.Panel2.Controls.Add(p7);
                    _questionPanel = p7;
                    break;
                case TypeQuestion.OneVariant:
                    PanelOneVariant p = new PanelOneVariant();
                    p.OnChangedProperty += OnChangedProperty;
                    p.Dock = DockStyle.Fill;
                    splitContainer2.Panel2.Controls.Add(p);
                    _questionPanel = p;
                    break;
                case TypeQuestion.Selection:
                    PanelSelection p8 = new PanelSelection();
                    p8.Dock = DockStyle.Fill;
                    p8.OnChangedProperty += OnChangedProperty;
                    splitContainer2.Panel2.Controls.Add(p8);
                    _questionPanel = p8;
                    break;
            }
            _uc = lo[type];
            splitContainer1.Panel2.Controls.Add(_uc);
            splitContainer1.Panel2.Invalidate();
            splitContainer2.Panel2.Invalidate();
        }

        void OnChangedProperty(TypeQuestion type)
        {
            IQuestion q = (IQuestion)_uc;
            q.SetData(_questionPanel.GetData());
        }
    }
}
