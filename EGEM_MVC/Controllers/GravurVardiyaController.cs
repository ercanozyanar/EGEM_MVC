using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EGEM_MVC.Models.EntityEgem;
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
    public class GravurVardiyaController : Controller
    {
        EGEM2023Entities db = new EGEM2023Entities();
        SqlConnection conn1 = new SqlConnection("Data Source=192.168.0.251;Initial Catalog=EGEM2022;Persist Security Info=True;User ID=egem;Password=123456");
        public static string adi;
        public static string fname;
        public static string kod;
        public static string kodsip;
        public static string vardiya;
        SqlCommand komut = new SqlCommand();
        public ActionResult GravurVar(int? Page_No)
        {
            var students = from stu in db.EO_GRAVUR_VARDIYA select stu;
            students = students.OrderByDescending(stu => stu.ID);
            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);
            return View(students.ToPagedList(No_Of_Page, Size_Of_Page));
        }
        public ActionResult GravurVardetay(int? id)
        {
            List<EO_GRAVUR_VARDIYA> studentList = db.EO_GRAVUR_VARDIYA.ToList();
            var std = studentList.Where(s => s.ID == id).FirstOrDefault();
            return View(std);
        }
    }
}