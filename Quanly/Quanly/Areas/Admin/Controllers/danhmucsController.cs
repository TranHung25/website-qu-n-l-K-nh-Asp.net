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
    public class danhmucsController : Controller
    {
        private QuanlyEntities db = new QuanlyEntities();

        // GET: Admin/danhmucs
        public async Task<ActionResult> Index()
        {
            return View(await db.danhmucs.ToListAsync());
        }

        // GET: Admin/danhmucs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            danhmuc danhmuc = await db.danhmucs.FindAsync(id);
            if (danhmuc == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc);
        }

        // GET: Admin/danhmucs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/danhmucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_danhmuc,tendanhmuc,thutu")] danhmuc danhmuc)
        {
            if (ModelState.IsValid)
            {
                db.danhmucs.Add(danhmuc);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(danhmuc);
        }

        // GET: Admin/danhmucs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            danhmuc danhmuc = await db.danhmucs.FindAsync(id);
            if (danhmuc == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc);
        }

        // POST: Admin/danhmucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_danhmuc,tendanhmuc,thutu")] danhmuc danhmuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhmuc).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(danhmuc);
        }

        // GET: Admin/danhmucs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            danhmuc danhmuc = await db.danhmucs.FindAsync(id);
            if (danhmuc == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc);
        }

        // POST: Admin/danhmucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            danhmuc danhmuc = await db.danhmucs.FindAsync(id);
            db.danhmucs.Remove(danhmuc);
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
