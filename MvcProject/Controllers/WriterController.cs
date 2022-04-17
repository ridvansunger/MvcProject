using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class WriterController : Controller
    {
        // GET: Writer
        //Business sınıfı çağırdık
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator validationRules = new WriterValidator();


        public ActionResult Index()
        {
            /*
             view içerisini doldurduk, verileri çektik .Lİsteleme yaptık burada sonra tekrar geri döndük altaki metoda geçtik(ekleme)
             */
            var writerValues = wm.GetList();
            return View(writerValues);
        }

        //Aşağıyı doldurduk PostDa add view dedik

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
           
            ValidationResult results = validationRules.Validate(writer);
            if(results.IsValid)
            {
                wm.WriterAdd(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        //Yazarı Düzenleme kısmı
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writerValue = wm.GetByID(id);
            return View(writerValue);
        }


        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {

            /*Addviewi yatouk sonra index içerisindeki carta bulunan profili düzenle butonuna gidip action tanımladık
             <a href="/Writer/EditWriter/@item.WriterID" class="btn btn-sm btn-primary">*/
            ValidationResult results = validationRules.Validate(writer);
            if (results.IsValid)
            {
                wm.WriterUpdate(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}