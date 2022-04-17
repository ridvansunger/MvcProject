using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        // GET: Heading
        public ActionResult Index()
        {
            var headingValues = hm.GetList();


            return View(headingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            //Dropdownlisti kullanmak
            //Sayfa yüklneriken liste göndereceğiz. gitmek istediğimiz tabloyu yukarıda newledim.
            //sorgumu yazdım
            //value member değerin ıd si => value member
            //display member değerin adı, text => display member
            //değeri viewbag yardımı ile taşıdık
            List<SelectListItem> valueCategory = (from t in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = t.CategoryName,
                                                      Value = t.CategoryID.ToString()
                                                  }).ToList();

            //yazar seçme işlemi
            //admini seçme işlemi yapacağız /yukarıda newwledik
            List<SelectListItem> valueWriter = (from t in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = t.WriterName + " " + t.WriterSurname,
                                                    Value = t.WriterID.ToString()
                                                }).ToList();



            ViewBag.valueListCategory = valueCategory;
            ViewBag.valueListWriter = valueWriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            //ekleme tarihini buradan verdik.
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAddBL(heading);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from t in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = t.CategoryName,
                                                      Value = t.CategoryID.ToString()
                                                  }).ToList();


            ViewBag.valueListCategory = valueCategory;
            var headingValue = hm.GetByID(id);
            return View(headingValue);
        }


        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            hm.HeadingUpdate(heading);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetByID(id);
            headingValue.HeadingStatus = false;
            hm.HeadingDelete(headingValue);

            return RedirectToAction("Index");
        }

    }
}