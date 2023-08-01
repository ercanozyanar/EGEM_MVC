using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EGEM_MVC.Models.Entity;
using PagedList.Mvc;
using PagedList;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Data;
using System.IO;
using System.Web.Security;
using ClosedXML.Excel;


namespace EGEM_MVC.Controllers
{
    public class Depo143BakiyeController : Controller
    {
        PILOTEntities db = new PILOTEntities();
        SqlConnection conn1 = new SqlConnection("Data Source=192.168.0.251;Initial Catalog=EGEM2022;Persist Security Info=True;User ID=egem;Password=123456");

        public ActionResult Depo143Bakiye(int? Page_No)
        {
            var students = from stu in db.EGEM_143_DEPO_BAKIYE select stu;
            students = students.OrderByDescending(stu => stu.STOK_KODU);
            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);
            return View(students.ToPagedList(No_Of_Page, Size_Of_Page));
        }
    }
}