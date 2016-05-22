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

namespace TestSite.Controllers
{
    public class QuestionTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /QuestionType/
        public async Task<ActionResult> Index()
        {
            return View(await db.QuestionTypes.ToListAsync());
        }

        // GET: /QuestionType/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionType questiontype = await db.QuestionTypes.FindAsync(id);
            if (questiontype == null)
            {
                return HttpNotFound();
            }
            return View(questiontype);
        }

        // GET: /QuestionType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /QuestionType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="QuestionTypeID,QuestionTypeName")] QuestionType questiontype)
        {
            if (ModelState.IsValid)
            {
                db.QuestionTypes.Add(questiontype);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(questiontype);
        }

        // GET: /QuestionType/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionType questiontype = await db.QuestionTypes.FindAsync(id);
            if (questiontype == null)
            {
                return HttpNotFound();
            }
            return View(questiontype);
        }

        // POST: /QuestionType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="QuestionTypeID,QuestionTypeName")] QuestionType questiontype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questiontype).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(questiontype);
        }

        // GET: /QuestionType/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionType questiontype = await db.QuestionTypes.FindAsync(id);
            if (questiontype == null)
            {
                return HttpNotFound();
            }
            return View(questiontype);
        }

        // POST: /QuestionType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            QuestionType questiontype = await db.QuestionTypes.FindAsync(id);
            db.QuestionTypes.Remove(questiontype);
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
