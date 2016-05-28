using IQuestionLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class FormCheckOlimp : Form
    {
        private LoadAssembles _la;
        private int _idTest;
        private List<Otvety> _questions;
        private List<UserControl> _questPanels;
        private int _indexQuestion = 0;
        private DateTime _allTime;
        private DateTime _currentTime;
        private bool[] _isAnswered;

        public FormCheckOlimp()
        {
            InitializeComponent();
            _allTime = new DateTime(2000, 1, 1, 0, 30, 0);
            _currentTime = new DateTime(2000, 1, 1, 0, 0, 0);
            _questions = new List<Otvety>();
        }

        public FormCheckOlimp(int idTest)
        {
            InitializeComponent();
            _la = new LoadAssembles(Application.StartupPath);
            _la.Load();
            _idTest = idTest;
            _questions = new List<Otvety>();
            _questPanels = new List<UserControl>();
        }

        private void LoadData()
        {
            treeView1.HideSelection = false;
            
            _questions.Clear();
            //получаем id всех олимпиад
            olimpiadyTableAdapter1.Fill(testDataSet1.Olimpiady);
            List<int> idsOlimp = new List<int>();
            List<string> namePredm = new List<string>();
            for (int j = 0; j < testDataSet1.Olimpiady.Rows.Count; j++)
            {
                int id = Convert.ToInt32(testDataSet1.Olimpiady.Rows[j][3]);
                idsOlimp.Add(id);
                namePredm.Add(testDataSet1.Olimpiady.Rows[j][0].ToString());
            }
            treeView1.BeginUpdate();
            for(int i = 0; i < idsOlimp.Count; i++)
            {
                testDataSet1.Ucheniki.Clear();
                uchenikiTableAdapter1.FillByOlimpId(testDataSet1.Ucheniki, idsOlimp[i]);
                
                TreeNode parent = treeView1.Nodes.Add(namePredm[i]);
                
                for (int j = 0; j < testDataSet1.Ucheniki.Rows.Count; j++)
                {
                    string fio = testDataSet1.Ucheniki.Rows[j][1].ToString() + " " +
                                testDataSet1.Ucheniki.Rows[j][2].ToString() + " " +
                                testDataSet1.Ucheniki.Rows[j][3].ToString();
                    TreeNode child = new TreeNode();
                    child.Text = fio;
                    parent.Nodes.Add(child);
                }
            }
            //заносим ответ в treeView
            treeView1.EndUpdate();

            //int idQuestion = Convert.ToInt32(testDataSet1.Voprosy.Rows[i][6]);

            ////получаем ответы на вопрос
            //TestDataSet.OtvetyDataTable table = new TestDataSet.OtvetyDataTable();
            ////otvetyTableAdapter1.FillByOtvety(table, Convert.ToInt32(idQuestion));
            //List<Otvety> otv = new List<Otvety>();
            //_questions.AddRange(ConvertDataTable.GetOtvety(table).ToArray());

            ////для каждого ответа проверяем правильный ли он
            //for (int j = 1; j < _questions.Count; j++ )
            //{
            //   // bool? b = otvety_naVoprosyTableAdapter1.IsRightAnswer(Convert.ToInt32(_questions[j].idOtveta));
            //    //_questions[j].isWright = (bool)b;
            //}

            ////получаем панели с вопросами по типу вопроса
            //TypeQuestion type = (TypeQuestion)(Convert.ToInt32(testDataSet1.Voprosy.Rows[i][0])-1);
            //UserControl panel = _la[type];
            //((IQuestion)panel).SetData(_questions);
            //_questPanels.Add(panel);
            
            //splitContainer2.Panel1.Controls.Add(_questPanels[_indexQuestion]);
            //splitContainer2.Panel1.Invalidate();
            //TreeNode[] node = treeView1.Nodes.Find(_indexQuestion.ToString(), false);
            //treeView1.SelectedNode = node[0];
        }

        private void FormUserTesting_Load(object sender, EventArgs e)
        {
            try
            {
                //voprosyTableAdapter1.FillByTestId(testDataSet1.Voprosy, _idTest);
                LoadData();
                dataGridView1.RowCount = 15;
                ///timer1.Tick += timer1_Tick;
                //timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (_indexQuestion > 0)
            {
                _indexQuestion--;
                splitContainer2.Panel1.Controls.Clear();
                splitContainer2.Panel1.Controls.Add(_questPanels[_indexQuestion]);
                splitContainer2.Panel1.Invalidate();
                TreeNode[] node = treeView1.Nodes.Find(_indexQuestion.ToString(), false);
                treeView1.SelectedNode = node[0];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_indexQuestion < _questPanels.Count - 1)
            {
                _indexQuestion++;
                splitContainer2.Panel1.Controls.Clear();
                splitContainer2.Panel1.Controls.Add(_questPanels[_indexQuestion]);
                splitContainer2.Panel1.Invalidate();
                TreeNode[] node = treeView1.Nodes.Find(_indexQuestion.ToString(), false);
                treeView1.SelectedNode = node[0];
            }
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //int ind = Convert.ToInt32(e.Node.Name);
            //splitContainer2.Panel1.Controls.Clear();
            //splitContainer2.Panel1.Controls.Add(_questPanels[ind]);
            //_indexQuestion = ind;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //bool b = ((IQuestion)_questPanels[_indexQuestion]).GetAnswer();
            //if (MessageBox.Show("Вы точно хотите завершить тестирование?", "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            //{
                
            //    int result = 0;
            //    for (int i = 0; i < _questPanels.Count; i++)
            //    {
            //        if (((IQuestion)_questPanels[i]).GetAnswer())
            //        {
            //            result++;
            //        }
            //    }
            //    MessageBox.Show("Ваш результат: " + result + " из " + _questPanels.Count, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Close();
            //}
        }
    }
}
