using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EGEM_MVC.Models.EntityEgem;
using System.Data.SqlClient;
using System.Web.Security;
using EGEM_MVC.Enums;
using EGEM_MVC.Services;

namespace EGEM_MVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        EGEM2023Entities db = new EGEM2023Entities();
        SqlConnection conn1 = new SqlConnection("Data Source=192.168.0.251;Initial Catalog=EGEM2023;Persist Security Info=True;User ID=egem;Password=123456");

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(EGEM_MVC_USER user)
        {
            var userIndb = db.EGEM_MVC_USER.FirstOrDefault(x => x.AD_SOYAD == user.AD_SOYAD && x.SIFRE == user.SIFRE);
            DateTime tarih = DateTime.Today;
            DateTime ltarih = Convert.ToDateTime("31.12.2023");
            if (tarih < ltarih)
            {
                if (userIndb != null)
                {
                    ViewBag.Alert = CommonServices.ShowAlert(Alerts.Success, "Employee added");
                    FormsAuthentication.SetAuthCookie(user.AD_SOYAD, false);
                    return RedirectToAction("Baskiekle", "EsnekBaski");
                }
                else
                {
                    ViewBag.Alert = CommonServices.ShowAlert(Alerts.Danger, "Kullanıcı Adı veya Şifre Hatalı...");
                    return View();
                }
            }
            else
            {
                ViewBag.Alert = CommonServices.ShowAlert(Alerts.Danger, "Kullanıcı Adı veya Şifre Hatalı...");
                return View();
            }
        }
    }
    



}