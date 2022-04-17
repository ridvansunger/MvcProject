
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    using EntityLayer.Concrete;
    public interface ICategoryService
    {
        //ilk başta burada tanımla içini managerde doldur.
        List<Category> GetList();

        void CategoryAddBL(Category category);

        //id ye göre işlem yap
        Category GetByID(int id);

        //silme işlemi
        void CategoryDelete(Category category);

        //güncelleme
        void CategoryUpdate(Category category);
    }
}
