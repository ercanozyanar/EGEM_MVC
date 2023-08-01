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
    public class DOFTakipController : Controller
    {
        EGEM2023Entities db = new EGEM2023Entities();
        SqlConnection conn1 = new SqlConnection("Data Source=192.168.0.251;Initial Catalog=EGEM2023;Persist Security Info=True;User ID=egem;Password=123456");
        public static string adi;
        public static string fname;
        public static string kod;
        public static string kodsip;
        public static string vardiya;
        SqlCommand komut = new SqlCommand();
        public ActionResult DOF(string Search_Data, string Filter_Value, int? Page_No)
        {

            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }
            ViewBag.FilterValue = Search_Data;
            var students = from stu in db.EGEM_DOFLIST select stu;
            if (!String.IsNullOrEmpty(Search_Data))
            {
                students = students.Where(stu => stu.ID.ToString().Contains(Search_Data.ToUpper()));
            }



            //var students = from stu in db.EGEM_DOFLIST select stu;
            students = students.OrderByDescending(stu => stu.ID);
            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);
            return View(students.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        public ActionResult DOFdetay(int? id)
        {
            List<EGEM_DOF_TAKIP> studentList = db.EGEM_DOF_TAKIP.ToList();
            var std = studentList.Where(s => s.ID == id).FirstOrDefault();
            return View(std);
        }

        public ActionResult Gorsel1(int? id)
        {
            string IMAGE_1 = "";
            conn1.Open();
            SqlCommand verioku = new SqlCommand("SELECT ID,IMAGE_1,IMAGE_2,IMAGE_3,IMAGE_4 FROM dbo.EGEM_DOF_TAKIP WHERE  (ID LIKE '2023%') AND ID= '" + id + "'", conn1);
            verioku.ExecuteNonQuery();
            SqlDataReader oku;
            oku = verioku.ExecuteReader();
            while (oku.Read())
            {
                IMAGE_1 = oku["IMAGE_1"].ToString();
            }
            oku.Close();
            conn1.Close();
            if (IMAGE_1 != "")
            {
                using (var client = new WebClient())
                {
                    var buffer = client.OpenRead(IMAGE_1);
                    return File(buffer, "Image/jpeg");
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Gorsel2(int? id)
        {
            string IMAGE_2 = "";
            conn1.Open();
            SqlCommand verioku = new SqlCommand("SELECT ID,IMAGE_1,IMAGE_2,IMAGE_3,IMAGE_4 FROM dbo.EGEM_DOF_TAKIP WHERE  (ID LIKE '2023%') AND ID= '" + id + "'", conn1);
            verioku.ExecuteNonQuery();
            SqlDataReader oku;
            oku = verioku.ExecuteReader();
            while (oku.Read())
            {
                IMAGE_2 = oku["IMAGE_2"].ToString();
            }
            oku.Close();
            conn1.Close();
            if (IMAGE_2 != "")
            {
                using (var client = new WebClient())
                {
                    var buffer = client.OpenRead(IMAGE_2);
                    return File(buffer, "Image/jpeg");
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Gorsel3(int? id)
        {
            string IMAGE_3 = "";
            conn1.Open();
            SqlCommand verioku = new SqlCommand("SELECT ID,IMAGE_1,IMAGE_2,IMAGE_3,IMAGE_4 FROM dbo.EGEM_DOF_TAKIP WHERE  (ID LIKE '2023%') AND ID= '" + id + "'", conn1);
            verioku.ExecuteNonQuery();
            SqlDataReader oku;
            oku = verioku.ExecuteReader();
            while (oku.Read())
            {
                IMAGE_3 = oku["IMAGE_3"].ToString();
            }
            oku.Close();
            conn1.Close();
            if (IMAGE_3 != "")
            {
                using (var client = new WebClient())
                {
                    var buffer = client.OpenRead(IMAGE_3);
                    return File(buffer, "Image/jpeg");
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Gorsel4(int? id)
        {
            string IMAGE_4 = "";
            conn1.Open();
            SqlCommand verioku = new SqlCommand("SELECT ID,IMAGE_1,IMAGE_2,IMAGE_3,IMAGE_4 FROM dbo.EGEM_DOF_TAKIP WHERE  (ID LIKE '2023%') AND ID= '" + id + "'", conn1);
            verioku.ExecuteNonQuery();
            SqlDataReader oku;
            oku = verioku.ExecuteReader();
            while (oku.Read())
            {
                IMAGE_4 = oku["IMAGE_4"].ToString();
            }
            oku.Close();
            conn1.Close();
            if (IMAGE_4 != "")
            {
                using (var client = new WebClient())
                {
                    var buffer = client.OpenRead(IMAGE_4);
                    return File(buffer, "Image/jpeg");
                }
            }
            else
            {
                return View();
            }
        }
    }
}