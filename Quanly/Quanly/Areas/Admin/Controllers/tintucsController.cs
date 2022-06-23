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
    public class tintucsController : Controller
    {
        private QuanlyEntities db = new QuanlyEntities();

        // GET: Admin/tintucs
        public async Task<ActionResult> Index()
        {
            var tintucs = db.tintucs.Include(t => t.danhmuc_tin);
            return View(await tintucs.ToListAsync());
        }

        // GET: Admin/tintucs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tintuc tintuc = await db.tintucs.FindAsync(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        // GET: Admin/tintucs/Create
        public ActionResult Create()
        {
            ViewBag.danhmuctin_id = new SelectList(db.danhmuc_tin, "danhmuctin_id", "tendanhmuc");
            return View();
        }

        // POST: Admin/tintucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "baiviet_id,tenbaiviet,mota,danhmuctin_id,hinhanh")] tintuc tintuc)
        {
            var f = Request.Files["hinhanh"];
            if (f != null && f.ContentLength > 0)
            {
                var path = Server.MapPath("~/Areas/assest/FileUpload/") + f.FileName;
                f.SaveAs(path);
                tintuc.hinhanh = f.FileName;
            }
            if (ModelState.IsValid)
            {
                db.tintucs.Add(tintuc);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.danhmuctin_id = new SelectList(db.danhmuc_tin, "danhmuctin_id", "tendanhmuc", tintuc.danhmuctin_id);
            return View(tintuc);
        }

        // GET: Admin/tintucs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tintuc tintuc = await db.tintucs.FindAsync(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            ViewBag.danhmuctin_id = new SelectList(db.danhmuc_tin, "danhmuctin_id", "tendanhmuc", tintuc.danhmuctin_id);
            return View(tintuc);
        }

        // POST: Admin/tintucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "baiviet_id,tenbaiviet,mota,danhmuctin_id,hinhanh")] tintuc tintuc)
        {
            var f = Request.Files["hinhanh"];
            if (f != null && f.ContentLength > 0)
            {
                var path = Server.MapPath("~/Areas/assest/FileUpload/") + f.FileName;
                f.SaveAs(path);
                tintuc.hinhanh = f.FileName;
            }
            if (ModelState.IsValid)
            {
                db.Entry(tintuc).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.danhmuctin_id = new SelectList(db.danhmuc_tin, "danhmuctin_id", "tendanhmuc", tintuc.danhmuctin_id);
            return View(tintuc);
        }

        // GET: Admin/tintucs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tintuc tintuc = await db.tintucs.FindAsync(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        // POST: Admin/tintucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tintuc tintuc = await db.tintucs.FindAsync(id);
            db.tintucs.Remove(tintuc);
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
