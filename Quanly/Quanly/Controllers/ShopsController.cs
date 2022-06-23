using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quanly.Models;
using Quanly.Models.framework;

namespace Quanly.Controllers
{
    public class ShopsController : Controller
    {
        QuanlyEntities objQuanlyEntities = new QuanlyEntities();
        // GET: Shops
        public ActionResult Index()
        {

            var lstsanpham = objQuanlyEntities.sanphams.ToList();
            return View(lstsanpham);
        }
    }
}