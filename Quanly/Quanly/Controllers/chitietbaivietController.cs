using Quanly.Models.framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanly.Controllers
{
    public class chitietbaivietController : Controller
    {
        QuanlyEntities objQuanlyEntities = new QuanlyEntities();
        // GET: chitietbaiviet
        public ActionResult Index(int Id)
        {
            var objtintuc = objQuanlyEntities.tintucs.Where(n => n.baiviet_id == Id).FirstOrDefault();
            return View(objtintuc);
        }
    }
}