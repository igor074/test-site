using IQuestionLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Test
{
    public class LoadAssembles
    {
        private string _path;
        private List<IQuestion> _controls;

        public UserControl this[TypeQuestion type]
        {
            get 
            {
                if (_controls != null)
                {
                    foreach (IQuestion q in _controls)
                        if (q.Type == type)
                            return q.ControlQuestion;
                }
                return null;
            }
        }

        public List<IQuestion> Controls
        {
          get { return _controls; }
          set { _controls = value; }
        }

        public LoadAssembles(string path)
        {
            _path = path;
            _controls = new List<IQuestion>();
        }

        public void Load()
        {
            if (Directory.Exists(_path + @"\dll"))
            {
                _controls.Clear();
                string[] files = Directory.GetFiles(_path + @"\dll", "*.dll", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    try 
                    {
                        Assembly asm = Assembly.LoadFile(file);
                        string className = Path.GetFileNameWithoutExtension(file);
                        IQuestion control = (IQuestion)asm.CreateInstance(string.Format("{0}.{0}", className), true);
                        if (control != null)
                            _controls.Add(control);
                    }
                    catch(Exception ex)
                    {
                        Debug.Fail(ex.Message);
                    }
                }
            }
        }
    }
}
