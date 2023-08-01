using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EGEM_MVC.Models.Entity;
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
using iTextSharp.text;

namespace EGEM_MVC.Controllers
{
    public class AktifUretimController : Controller
    {
        PILOTEntities db = new PILOTEntities();
        EGEM2023Entities eb = new EGEM2023Entities();
        SqlConnection conn1 = new SqlConnection("Data Source=192.168.0.251;Initial Catalog=PILOT;Persist Security Info=True;User ID=egem;Password=123456");
        SqlConnection conn2 = new SqlConnection("Data Source=192.168.0.251;Initial Catalog=EGEM2023;Persist Security Info=True;User ID=egem;Password=123456");

        public static string adi;
        public static string fname;
        public static string kod;
        public static string kodsip;
        SqlCommand komut = new SqlCommand();
        public ActionResult Aktifuretlist(String Search_Data, String Filter_Value, String FilterSip_Value, int? Page_No)
        {
            kod = Search_Data;
            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }
            ViewBag.FilterValue = Search_Data;

            var students = from stu in db.EGEM_AKTIFURETIM select stu;
            if (!String.IsNullOrEmpty(Search_Data))
            {
                students = students.Where(stu => stu.SIPARIS_NO.ToString().Contains(Search_Data.ToString()));
            }
            //-----------------------------------------------------------------------------------------------------
            students = students.OrderByDescending(stu => stu.SIPARIS_NO);
            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);
            return View(students.ToPagedList(No_Of_Page, Size_Of_Page));
        }
  
        public ActionResult Aktifuretdetay(int? kodx)
        {
            return View();
            
        }
        public ActionResult Aktifdetay(int? id)
        {

            string STOK = "";
            string imaj = "";
            conn1.Open();
            SqlCommand verioku = new SqlCommand("Select* FROM EGEM_AKTIFURETIM WHERE ID= '" + id + "'", conn1);
            verioku.ExecuteNonQuery();
            SqlDataReader oku;
            oku = verioku.ExecuteReader();
            while (oku.Read())
            {

                STOK = oku["STOK_KODU"].ToString();
            }

            oku.Close();
            conn1.Close();

            conn2.Open();
            SqlCommand verioku2 = new SqlCommand("Select* FROM EGEM_ORJINAL_IMAJ WHERE STOK_KODU= '" + STOK + "'", conn2);
            verioku2.ExecuteNonQuery();
            SqlDataReader oku2;
            oku2 = verioku2.ExecuteReader();
            while (oku2.Read())
            {

                imaj = oku2["orjinal_imaj"].ToString();
            }
            //string yazi = "çiitii";
            //string yeni_yazi = yazi.Replace("ii", "e");

            oku.Close();
            conn1.Close();

            if (imaj != "")
            {
                using (var client = new WebClient())
                {
                    var buffer = client.OpenRead(imaj);
                    return File(buffer, "application/pdf");
                }
            }
            else
            {
                return View();
            }


        }
    }

}