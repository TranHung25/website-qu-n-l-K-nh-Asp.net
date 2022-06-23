using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using Quanly.Models.framework;

namespace Quanly.Areas.Admin.Controllers
{
    [Authorize]
    public class sanphamsController : Controller
    {
        private QuanlyEntities db = new QuanlyEntities();

        // GET: Admin/sanphams
        public async Task<ActionResult> Index()
        {
            var sanphams = db.sanphams.Include(s => s.danhmuc);
            
            return View(await sanphams.ToListAsync());
        }

        // GET: Admin/sanphams/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanpham sanpham = await db.sanphams.FindAsync(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // GET: Admin/sanphams/Create
        public ActionResult Create()
        {
            ViewBag.id_danhmuc = new SelectList(db.danhmucs, "id_danhmuc", "tendanhmuc");
            return View();
        }

        // POST: Admin/sanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_sanpham,tensanpham,giasp,soluong,hinhanh,mota,tinhtrang,id_danhmuc")] sanpham sanpham)
        {
            var f = Request.Files["hinhanh"];
            if (f != null && f.ContentLength > 0)
            {
                var path = Server.MapPath("~/Areas/assest/FileUpload/") + f.FileName;
                f.SaveAs(path);
                sanpham.hinhanh = f.FileName;
            }
            if (ModelState.IsValid)
            {
                db.sanphams.Add(sanpham);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_danhmuc = new SelectList(db.danhmucs, "id_danhmuc", "tendanhmuc", sanpham.id_danhmuc);
            return View(sanpham);
        }

        // GET: Admin/sanphams/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanpham sanpham = await db.sanphams.FindAsync(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_danhmuc = new SelectList(db.danhmucs, "id_danhmuc", "tendanhmuc", sanpham.id_danhmuc);
            return View(sanpham);
        }

        // POST: Admin/sanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_sanpham,tensanpham,giasp,soluong,hinhanh,mota,tinhtrang,id_danhmuc")] sanpham sanpham)
        {
            var f = Request.Files["hinhanh"];
            if (f != null && f.ContentLength > 0)
            {
                var path = Server.MapPath("~/Areas/assest/FileUpload/") + f.FileName;
                f.SaveAs(path);
                sanpham.hinhanh = f.FileName;
            }
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_danhmuc = new SelectList(db.danhmucs, "id_danhmuc", "tendanhmuc", sanpham.id_danhmuc);
            return View(sanpham);
        }

        // GET: Admin/sanphams/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanpham sanpham = await db.sanphams.FindAsync(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // POST: Admin/sanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            sanpham sanpham = await db.sanphams.FindAsync(id);
            db.sanphams.Remove(sanpham);
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
