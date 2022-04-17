using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic

        Context db = new Context();
        public ActionResult Index()
        {

            //Toplam kategori sayısı
            var totalCategory = db.Categories.Count();
            ViewBag.totalNumberOfCategory = totalCategory;

            //yazılım kategorisi başlık sayısı
            var softwareCategory = db.Headings.Count(t => t.Category.CategoryName == "Yazılım");
            ViewBag.softwareCategoryTitleNumber = softwareCategory;

            //Yazar adında a harfi geçen yazar sayısı
            var writeNameSortByA = db.Writers.Count(t => t.WriterName.Contains("a"));
            ViewBag.writerNameSByA = writeNameSortByA;

            //En fazla başlığa sahip kategori
            var mostTitles = db.Headings.Max(t => t.Category.CategoryName);
            ViewBag.CategoryNameMost = mostTitles;

            //kategori tablosundaki aktif kategori sayısı
            var categoryStatusTrue = db.Categories.Count(t => t.CategoryStatus == true);
            ViewBag.ActiveCategories = categoryStatusTrue;

            //yazar sayısı
            var totalWriter = db.Writers.Count();
            ViewBag.TotalWriter = totalWriter;

            string session = (string)Session["AdminMail"];
            ViewBag.a = session;

            return View();
        }
    }
}