using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSite.Models
{
    public class Test
    {
        public int TestID { get; set; }
        public string TestName { get; set; }

        public ICollection<Question> Questions { get; set; }

        public Test()
        {
            Questions = new List<Question>();
        }
    }
}