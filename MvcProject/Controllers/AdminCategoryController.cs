
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

    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory


        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
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
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult results = validationRules.Validate(category);

            if (results.IsValid)
            {
                cm.CategoryAddBL(category);
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


        public ActionResult DeleteCategory(int id)
        {
            /*Buranın kendine ait view olmayacak Index üzerine çağırılarak kurulacak
             * Index uzerinden sil butunona gittik ve href i verdik ilk basşta # vermiştirk.
             * <td><a href="/AdminCategory/DeleteCategory/@item.CategoryID" class="btn btn-danger">Sil</a></td>
             * id yi item üzerinden verdik buton üstüne gelince id si görünüyor. Silme işlemi nesneyi silme olarak yapılarak yapılacak. GetByID ile nesnenin bütün kaytlarını alırsın
             * 
             */

            var categoryValues = cm.GetByID(id);
            cm.CategoryDelete(categoryValues);
            //sildikten sonra yine index e yönlendir. 
            //ilişki tablolarda silme değilde statu üzerinden gideceğiz
            return RedirectToAction("Index");
        }


        //Update işlemi için iki adım vardır.1-Güncellenecek bilgilerin güncellenme sayfasına taşınması işlemi,2- güncellemenin 
        //yapılması işlemi
        /*ilk önce güncellenecek kategori bul
         
         */

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryValue = cm.GetByID(id);
            cm.CategoryUpdate(categoryValue);

            //bana değişkenle beraber view döndür. ve HttpGet ile çalış.Sayfa yüklendiği zaman çalış
            //EditCategory view i ne gitmek için index de bulunan butona path yazdık
            // <td><a href="#" class="btn btn-warning">Güncelle</a></td>
            //EditCategory.cshtml içini doldurduk
            //HttpPost methodunu yaptık sonra
            return View(categoryValue);

        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            cm.CategoryUpdate(category);
            return RedirectToAction("Index");
        }

    }
}