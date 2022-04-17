using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        //ilk başta burada tanımla içini managerde doldur.
        List<About> GetList();

        void AboutAddBL(About about);

        //id ye göre işlem yap
        About GetByID(int id);

        //silme işlemi
        void AboutDelete(About about);

        //güncelleme
        void AboutUpdate(About about);
    }
}
