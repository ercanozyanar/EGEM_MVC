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
    public class ListeController : Controller
    {
        PILOTEntities db = new PILOTEntities();
        SqlConnection conn1 = new SqlConnection("Data Source=192.168.0.251;Initial Catalog=EGEM2022;Persist Security Info=True;User ID=egem;Password=123456");
        public static string adi;
        public static string fname;
        public static string kod;
        public static string kodsip;
        SqlCommand komut = new SqlCommand();

        public ActionResult depo10list(String Search_Data, String Filter_Value, String FilterSip_Value, int? Page_No)
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

            var students = from stu in db.EGEM_10_DEPO_BAKIYE select stu;
            if (!String.IsNullOrEmpty(Search_Data))
            {
                students = students.Where(stu => stu.STOK_ADI.ToString().Contains(Search_Data.ToString()));
            }
            //-----------------------------------------------------------------------------------------------------
            students = students.OrderByDescending(stu => stu.STOK_KODU);
            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);
            return View(students.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        [HttpPost]
        public ActionResult Export(string Search_Data, string Filter_Value)
        {
            PILOTEntities entities = new PILOTEntities();
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[3]
            {
                new DataColumn("STOK_KODU"),
                new DataColumn("STOK_ADI"),
                new DataColumn("BAKIYE"),

            });
            var customers = from stu in entities.EGEM_10_DEPO_BAKIYE select stu;
            customers = customers.Where(stu => stu.STOK_ADI.ToString().Contains(kod.ToString()));
            foreach (var customer in customers.ToList())
            {
                dt.Rows.Add(
                    customer.STOK_KODU,
                    customer.STOK_ADI,
                    customer.DEPO10
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
