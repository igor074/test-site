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
    public class OlympiadController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Olympiad/
        public async Task<ActionResult> Index()
        {
            return View(await db.Olympiads.ToListAsync());
        }

        // GET: /Olympiad/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Olympiad olympiad = await db.Olympiads.FindAsync(id);
            if (olympiad == null)
            {
                return HttpNotFound();
            }
            return View(olympiad);
        }

        // GET: /Olympiad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Olympiad/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="OlympiadID,Subject,Status,Condition")] Olympiad olympiad)
        {
            if (ModelState.IsValid)
            {
                db.Olympiads.Add(olympiad);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(olympiad);
        }

        // GET: /Olympiad/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Olympiad olympiad = await db.Olympiads.FindAsync(id);
            if (olympiad == null)
            {
                return HttpNotFound();
            }
            return View(olympiad);
        }

        // POST: /Olympiad/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="OlympiadID,Subject,Status,Condition")] Olympiad olympiad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(olympiad).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(olympiad);
        }

        // GET: /Olympiad/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Olympiad olympiad = await db.Olympiads.FindAsync(id);
            if (olympiad == null)
            {
                return HttpNotFound();
            }
            return View(olympiad);
        }

        // POST: /Olympiad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Olympiad olympiad = await db.Olympiads.FindAsync(id);
            db.Olympiads.Remove(olympiad);
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
