using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quanly.Models;
using Quanly.Models.framework;

namespace Quanly.Controllers
{
    public class ChitietsanphamController : Controller
    {
        QuanlyEntities objQuanlyEntities = new QuanlyEntities();
        // GET: Chitietsanpham
        public ActionResult Index(int Id)
        {
            var objsanpham = objQuanlyEntities.sanphams.Where(n=>n.id_sanpham == Id).FirstOrDefault();
            return View(objsanpham);
        }
    }
}