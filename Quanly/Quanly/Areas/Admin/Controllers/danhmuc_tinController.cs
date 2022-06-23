using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Quanly.Models.framework;

namespace Quanly.Areas.Admin.Controllers
{
    public class danhmuc_tinController : Controller
    {
        private QuanlyEntities db = new QuanlyEntities();

        // GET: Admin/danhmuc_tin
        public async Task<ActionResult> Index()
        {
            return View(await db.danhmuc_tin.ToListAsync());
        }

        // GET: Admin/danhmuc_tin/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            danhmuc_tin danhmuc_tin = await db.danhmuc_tin.FindAsync(id);
            if (danhmuc_tin == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc_tin);
        }

        // GET: Admin/danhmuc_tin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/danhmuc_tin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "danhmuctin_id,tendanhmuc")] danhmuc_tin danhmuc_tin)
        {
            if (ModelState.IsValid)
            {
                db.danhmuc_tin.Add(danhmuc_tin);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(danhmuc_tin);
        }

        // GET: Admin/danhmuc_tin/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            danhmuc_tin danhmuc_tin = await db.danhmuc_tin.FindAsync(id);
            if (danhmuc_tin == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc_tin);
        }

        // POST: Admin/danhmuc_tin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "danhmuctin_id,tendanhmuc")] danhmuc_tin danhmuc_tin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhmuc_tin).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(danhmuc_tin);
        }

        // GET: Admin/danhmuc_tin/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            danhmuc_tin danhmuc_tin = await db.danhmuc_tin.FindAsync(id);
            if (danhmuc_tin == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc_tin);
        }

        // POST: Admin/danhmuc_tin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            danhmuc_tin danhmuc_tin = await db.danhmuc_tin.FindAsync(id);
            db.danhmuc_tin.Remove(danhmuc_tin);
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
