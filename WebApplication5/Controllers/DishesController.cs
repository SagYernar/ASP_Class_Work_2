using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication5;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class DishesController : Controller
    {
        private BurgerContext db = new BurgerContext();

        // GET: Dishes
        public async Task<ActionResult> Index()
        {
            var dishes = db.Dishes.Include(d => d.DishesType);
            return View(await dishes.ToListAsync());
        }

        // GET: Dishes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dishes dishes = await db.Dishes.FindAsync(id);
            if (dishes == null)
            {
                return HttpNotFound();
            }
            return View(dishes);
        }

        // GET: Dishes/Create
        public ActionResult Create()
        {
            ViewBag.DishesTypeId = new SelectList(db.DishesTypes, "Id", "Name");
            return View();
        }

        // POST: Dishes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,Price,Rating,DishesTypeId")] Dishes dishes)
        {
            if (ModelState.IsValid)
            {
                db.Dishes.Add(dishes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DishesTypeId = new SelectList(db.DishesTypes, "Id", "Name", dishes.DishesTypeId);
            return View(dishes);
        }

        // GET: Dishes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dishes dishes = await db.Dishes.FindAsync(id);
            if (dishes == null)
            {
                return HttpNotFound();
            }
            ViewBag.DishesTypeId = new SelectList(db.DishesTypes, "Id", "Name", dishes.DishesTypeId);
            return View(dishes);
        }

        // POST: Dishes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,Price,Rating,DishesTypeId")] Dishes dishes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dishes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DishesTypeId = new SelectList(db.DishesTypes, "Id", "Name", dishes.DishesTypeId);
            return View(dishes);
        }

        // GET: Dishes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dishes dishes = await db.Dishes.FindAsync(id);
            if (dishes == null)
            {
                return HttpNotFound();
            }
            return View(dishes);
        }

        // POST: Dishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Dishes dishes = await db.Dishes.FindAsync(id);
            db.Dishes.Remove(dishes);
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
