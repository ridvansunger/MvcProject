using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    using BusinessLayer.Abstract;
    using DataAccessLayer.Absract;
    using DataAccessLayer.Concrete.Repositories;
    using EntityLayer.Concrete;
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        //class ismi üzeirnde
        //ctrl + nokta deyip ctor u hazır şekilde oluşturduk
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAddBL(Category category)
        {
            //burası çalışır amcak validator için kurallar controller tarafında çağırılır.
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            //buraya gelen delete metodu GenericRepodan gelen delete
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetByID(int id)
        {
            //id dye eşit olup olmadığını sorguladık
            return _categoryDal.Get(t=>t.CategoryID==id);
        }

        public List<Category> GetList()
        {
            //ICategoryDal üzerinden  listeyi aldık. nokta değince <IRepodan> , generic repodaki metotlara ulalabiliyoruz.
            //Bundan sonra CategoryManager da kullanmak için dal katmanında Entity klasörü oluşturduk
            return _categoryDal.List();
        }

        


        //public void CategoryAddBl()
        //{

        //}

     

    }
}
