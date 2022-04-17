
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    using BusinessLayer.Concrete;
    using BusinessLayer.ValidationRules;
    using DataAccessLayer.EntityFramework;
    using EntityLayer.Concrete;
    using FluentValidation.Results;

    public class CategoryController : Controller
    {
        //Dbden cekmek için Business lyer katmanındaki CategoryManager ı çğırdık

        //Efdeki değeri buraya verdik
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
           var categoryValues = cm.GetList();

            return View(categoryValues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            //ekleme yapmadan önce kontroller ettik
            // cm.CategoryAddBl(category);
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);

            if (results.IsValid)
            {
                cm.CategoryAddBL(category);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                //hatanın adı ve hatanın mesaını gönderiyoruz
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();

        }


    }
}