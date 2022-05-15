using Demo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo1.Controllers
{

    public class TaiKhoanController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: TaiKhoan
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var tendn = collection["USERNAME"];
            var matkhau = collection["PASS"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Error1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Error2"] = "Phải nhập mật khẩu";
            }
            else
            {
                // Gán giá trị cho đối tượng được tạo mới(kh)
                NGUOIDUNG kh = data.NGUOIDUNGs.SingleOrDefault(n => n.MSSV == tendn && n.PASS == matkhau);
                if (kh != null && kh.MAQUYEN == 0)
                {
                    Session["TaiKhoanKH"] = kh;
                    return RedirectToAction("Index", "Home");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection collection, NGUOIDUNG nd)
        {
            var check = data.NGUOIDUNGs.Where(m => m.MSSV == nd.MSSV).FirstOrDefault();
            if (check != null)
            {
                ViewData["CheckMail"] = "Tài Khoản Này Đã Được Sử Dụng";
                return this.Register();
            }
            else
            {
                var MSSV = collection["MSSV"];
                var pass = collection["PASS"];
                var rePass = collection["MatKhauXacNhan"];
                var TenSV = collection["HOVATEN"];
                var sdt = collection["SDT"];
                var GioiTinh = collection["GIOITINH"];
                var Gmail = collection["GMAIL"];
                var Lop = collection["LOP"];

                if (String.IsNullOrEmpty(rePass))
                {
                    ViewData["NhapMKXN"] = "Phải nhập mật khẩu xác nhận!";
                }
                else
                {
                    if (!pass.Equals(rePass))
                    {
                        ViewData["MatKhauGiongNhau"] = "Mật khẩu và mật khẩu xác nhận phải giống nhau!";
                    }
                    else
                    {
                        //Gán giá trị cho đổi tượng được tạo mới (kh)
                        nd.MSSV = MSSV;
                        nd.PASS = pass;
                        nd.HOVATEN = TenSV;
                        nd.SDT = sdt;
                        nd.GIOITINH = int.Parse(GioiTinh);
                        nd.GMAIL = Gmail;
                        nd.LOP = Lop;

                        data.NGUOIDUNGs.InsertOnSubmit(nd);
                        data.SubmitChanges();
                    }
                    return RedirectToAction("Login", "TaiKhoan");
                }
            }
        }
    }
}