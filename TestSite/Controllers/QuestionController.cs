using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestSite.Models;
using Newtonsoft.Json;

namespace TestSite.Controllers
{
    public class QuestionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Question/
        public async Task<ActionResult> Index()
        {
            var questions = db.Questions.Include(q => q.QuestionArea).Include(q => q.QuestionType);
            return View(await questions.ToListAsync());
        }

        // GET: /Question/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = await db.Questions.FindAsync(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: /Question/Create
        public ActionResult Create()
        {
            ViewBag.QuestionAreaID = new SelectList(db.QuestionAreas, "QuestionAreaID", "QuestionAreaName");
            ViewBag.QuestionTypeID = new SelectList(db.QuestionTypes, "QuestionTypeID", "QuestionTypeName");
            return View();
        }

        // POST: /Question/Create
        [HttpPost]
        public async Task<ActionResult> Create(Question question)
        {
            object body = JsonConvert.DeserializeObject(Request.Form[0]);
            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionAreaID = new SelectList(db.QuestionAreas, "QuestionAreaID", "QuestionAreaName", question.QuestionAreaID);
            ViewBag.QuestionTypeID = new SelectList(db.QuestionTypes, "QuestionTypeID", "QuestionTypeName", question.QuestionTypeID);
            return View(question);
        }

        // GET: /Question/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = await db.Questions.FindAsync(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionAreaID = new SelectList(db.QuestionAreas, "QuestionAreaID", "QuestionAreaName", question.QuestionAreaID);
            ViewBag.QuestionTypeID = new SelectList(db.QuestionTypes, "QuestionTypeID", "QuestionTypeName", question.QuestionTypeID);
            return View(question);
        }

        // POST: /Question/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="QuestionID,QuestionTypeID,QuestionAreaID,Complexity,Text,Points,ImagePath")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionAreaID = new SelectList(db.QuestionAreas, "QuestionAreaID", "QuestionAreaName", question.QuestionAreaID);
            ViewBag.QuestionTypeID = new SelectList(db.QuestionTypes, "QuestionTypeID", "QuestionTypeName", question.QuestionTypeID);
            return View(question);
        }

        // GET: /Question/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = await db.Questions.FindAsync(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: /Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Question question = await db.Questions.FindAsync(id);
            db.Questions.Remove(question);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
