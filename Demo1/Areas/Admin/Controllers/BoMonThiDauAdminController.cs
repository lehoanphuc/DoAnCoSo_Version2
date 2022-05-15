using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo1.Areas.Admin.Controllers
{
    public class BoMonThiDauAdminController : Controller
    {
        // GET: Admin/BoMonThiDau
        public ActionResult BongDaAdmin()
        {
            return View();
        }
        public ActionResult BongChuyenAdmin()
        {
            return View();
        }
        public ActionResult CauLongAdmin()
        {
            return View();
        }
        public ActionResult KeoCoAdmin()
        {
            return View();
        }
        public ActionResult CoVua_CoTuongAdmin()
        {
            return View();
        }
        public ActionResult DienKinhAdmin()
        {
            return View();
        }
    }
}