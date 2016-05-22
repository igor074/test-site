using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSite.Models;

namespace TestSite.Controllers
{
    public class PartialsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /Partials/
        public ActionResult Index(int? questionTypeId, int? questionId)
        {
            Question question = new Question();
            if (questionId.HasValue)
                question = db.Questions.Find(questionId);

            QuestionModelView qmv = new QuestionModelView(question, questionTypeId.Value);
            return PartialView("_PartialQuestion", qmv);
        }
	}
}