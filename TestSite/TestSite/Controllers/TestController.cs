using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSite.Models;

namespace TestSite.Controllers
{
    public class TestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: /Test/
        public ActionResult Index()
        {
            List<QuestionArea> areas = db.QuestionAreas.ToList();

            TestViewModel tvm = new TestViewModel();

            foreach (var area in areas)
            {
                tvm.Areas.Add(new SelectListItem() { Text = area.QuestionAreaName });
            }

            tvm.TestName = "Тест №1";
            tvm.TestTime = 40;

            return View(tvm);
        }
	}
}