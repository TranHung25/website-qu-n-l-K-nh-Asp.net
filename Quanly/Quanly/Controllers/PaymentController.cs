using Quanly.Models;
using Quanly.Models.framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanly.Controllers
{
    
    public class PaymentController : Controller
    {
        QuanlyEntities objQuanlyEntities = new QuanlyEntities();
        // GET: Payment
        public ActionResult Index()
        {
            if(Session["idUser"] == null)
            {
                return RedirectToAction("Login", "HomePage");
            }
            else
            {
                //Lấy thông tin từ giở hnagf từ biến session
                var lstCart = (List<CartModel>)Session["cart"];
                //gán dữ liệu cho Order
                Order objOrder = new Order();
                objOrder.Name = "DonHang-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                objOrder.UserId = int.Parse(Session["idUser"].ToString());
                objOrder.CreatedOnUtc = DateTime.Now;
                objOrder.Status = 1;
                objQuanlyEntities.Orders.Add(objOrder);
                //Lưu thông tin dữ liệu vào bảng order
                objQuanlyEntities.SaveChanges();

                //Lấy Order vừa mới tạo để lưu vào bảng OrderDetail
                int intOrderId = objOrder.Id;

                List<OrderDetail> lstOrderDetail = new List<OrderDetail>();

                foreach (var item in lstCart)
                {
                    OrderDetail obj = new OrderDetail();
                    obj.Quantity = item.Quantity;
                    obj.OrderId = intOrderId;
                    obj.ProductId = item.sanpham.id_sanpham;
                    lstOrderDetail.Add(obj);
                }

                objQuanlyEntities.OrderDetails.AddRange(lstOrderDetail);
                objQuanlyEntities.SaveChanges();


            }
            return View();
        }
    }
}