using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quanly.Models;
using Quanly.Models.framework;

namespace Quanly.Controllers
{
    public class CartController : Controller
    {
        QuanlyEntities objQuanlyEntities = new QuanlyEntities();
        // GET: Cart
        public ActionResult Index()
        {
            ViewBag.tongtien = tinhtongtien();
            return View((List<CartModel>)Session["cart"]);
        }

        public ActionResult AddToCart(int Id, int Quantity)
        {
            if (Session["cart"] == null)
            {
                List<CartModel> cart = new List<CartModel>();
                cart.Add(new CartModel { sanpham = objQuanlyEntities.sanphams.Find(Id), Quantity = Quantity });
                Session["cart"] = cart;
                Session["count"] = 1;
            }
            else
            {
                List<CartModel> cart = (List<CartModel>)Session["cart"];
                //kiểm tra sản phẩm có tồn tại trong giỏ hàng chưa???
                int index = isExist(Id);
                if (index != -1)
                {
                    //nếu sp tồn tại trong giỏ hàng thì cộng thêm số lượng
                    cart[index].Quantity += Quantity;
                }
                else
                {
                    //nếu không tồn tại thì thêm sản phẩm vào giỏ hàng
                    cart.Add(new CartModel { sanpham = objQuanlyEntities.sanphams.Find(Id), Quantity = Quantity });
                    //Tính lại số sản phẩm trong giỏ hàng
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                }
                Session["cart"] = cart;
            }
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
            
        }

        private int isExist(int Id)
        {
            List<CartModel> cart = (List<CartModel>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].sanpham.id_sanpham.Equals(Id))
                    return i;
            return -1;
        }

        //xóa sản phẩm khỏi giỏ hàng theo id
        public ActionResult Remove(int Id)
        {
            List<CartModel> li = (List<CartModel>)Session["cart"];
            li.RemoveAll(x => x.sanpham.id_sanpham == Id);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }
        public double tinhtongtien()
        {
            List<CartModel> cart = (List<CartModel>)Session["cart"];
            return cart.Sum(x => x.sanpham.giasp.Value * x.Quantity);
        }
    }
}