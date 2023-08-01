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
    public class ProjeSilindirController : Controller
    {
        EGEM2023Entities db = new EGEM2023Entities();
        SqlConnection conn1 = new SqlConnection("Data Source=192.168.0.251;Initial Catalog=EGEM2022;Persist Security Info=True;User ID=egem;Password=123456");
        public static string adi;
        public static string fname;
        public static string kod;
        public static string kodsip;
        SqlCommand komut = new SqlCommand();
        public ActionResult ProjeSilindir(String Search_Data, String Filter_Value, String FilterSip_Value, int? Page_No)
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

            var students = from stu in db.EGEM_PROJESILINDIR_TALEP select stu;
            if (!String.IsNullOrEmpty(Search_Data))
            {
                students = students.Where(stu => stu.SIPARIS_TARIHI.ToString().Contains(Search_Data.ToString()));
            }
            //-----------------------------------------------------------------------------------------------------
            students = students.OrderByDescending(stu => stu.SIPARIS_NO);
            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);
            return View(students.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        [HttpPost]
        public ActionResult Export(string Search_Data, string Filter_Value)
        {
            EGEM2023Entities entities = new EGEM2023Entities();
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[8]
            {
                new DataColumn("SIPARIS TARIHI"),
                new DataColumn("SIPARIS NO"),
                new DataColumn("TALEP NO"),
                new DataColumn("CARI KODU"),
                new DataColumn("CARI ISIM"),
                new DataColumn("STOK KODU"),
                new DataColumn("STOK ADI"),
                new DataColumn("MIKTAR"),
                
            });
            var customers = from stu in entities.EGEM_PROJESILINDIR_TALEP select stu;
            customers = customers.Where(stu => stu.SIPARIS_TARIHI.ToString().Contains(kod.ToString()));
            foreach (var customer in customers.ToList())
            {
                dt.Rows.Add(
                    customer.SIPARIS_TARIHI,
                    customer.SIPARIS_NO,
                    customer.TALEP_NO,
                    customer.CARI_KODU,
                    customer.CARI_ISIM,
                    customer.STOK_KODU,
                    customer.STOK_ADI,
                    customer.MIKTAR
                  
                    );
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");

                }
            }

        }
    }
}