using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Quanly.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(model.DTO.account acc)
        {
            if (ModelState.IsValid)
            {
                int isVal = model.DAO.account.checkLoginUS(acc.username, acc.password);

                if (isVal == 1)
                {
                    string ReturnUrl = "";
                    Session["username"] = acc.username;
                    FormsAuthentication.SetAuthCookie(acc.username, false);
                    FormsAuthentication.SetAuthCookie(acc.password, false);
                    if (Request.QueryString["ReturnUrl"] == null)
                        ReturnUrl = "~/Admin/sanphams/Index";
                    else ReturnUrl = Request.QueryString["ReturnUrl"].ToString();
                    return Redirect(ReturnUrl);
                }
                else
                {
                    // error
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng!");
                }
            }
            return View(acc);
        }
    }
}