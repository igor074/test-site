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
    public class QuestionAreaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /QuestionArea/
        public async Task<ActionResult> Index()
        {
            return View(await db.QuestionAreas.ToListAsync());
        }

        // GET: /QuestionArea/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionArea questionarea = await db.QuestionAreas.FindAsync(id);
            if (questionarea == null)
            {
                return HttpNotFound();
            }
            return View(questionarea);
        }

        // GET: /QuestionArea/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /QuestionArea/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="QuestionAreaID,QuestionAreaName")] QuestionArea questionarea)
        {
            if (ModelState.IsValid)
            {
                db.QuestionAreas.Add(questionarea);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(questionarea);
        }

        // GET: /QuestionArea/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionArea questionarea = await db.QuestionAreas.FindAsync(id);
            if (questionarea == null)
            {
                return HttpNotFound();
            }
            return View(questionarea);
        }

        // POST: /QuestionArea/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="QuestionAreaID,QuestionAreaName")] QuestionArea questionarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionarea).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(questionarea);
        }

        // GET: /QuestionArea/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionArea questionarea = await db.QuestionAreas.FindAsync(id);
            if (questionarea == null)
            {
                return HttpNotFound();
            }
            return View(questionarea);
        }

        // POST: /QuestionArea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            QuestionArea questionarea = await db.QuestionAreas.FindAsync(id);
            db.QuestionAreas.Remove(questionarea);
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
