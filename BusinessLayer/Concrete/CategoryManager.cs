using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    using DataAccessLayer.Concrete.Repositories;
    using EntityLayer.Concrete;
    public class CategoryManager
    {
        GenericRepository<Category> repo = new GenericRepository<Category>();

        public List<Category> GetAllBl()
        {
            return repo.List();
        }

        public void CategoryAddBl(Category category)
        {
            if(category.CategoryName=="" || category.CategoryName.Length<=3 || category.CategoryDescription=="" || category.CategoryName
                .Length>=51)
            {
                // hata
            }
            else
            {
                repo.Insert(category);
            }
        }
    }
}
