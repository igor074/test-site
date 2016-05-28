using IQuestionLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public static class ConvertDataTable
    {
        public static List<Otvety> GetOtvety(TestDataSet.OtvetyDataTable table)
        {
            List<Otvety> res = new List<Otvety>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Otvety o = new Otvety();
                o.textOtveta = table.Rows[i][0].ToString();
                o.idOtveta = Convert.ToInt32(table.Rows[i][1]);
                res.Add(o);
            }
            return res;
        }
    }
}
