using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        //ilk başta burada tanımla içini managerde doldur.
        List<Content> GetList();

        //paremetreli listeleme
        List<Content> GetListByHeadingID(int id);

        void ContentAddBL(Content content);

        //id ye göre işlem yap
        Content GetByID(int id);

        //silme işlemi
        void ContentDelete(Content content);

        //güncelleme
        void ContentUpdate(Content content);


    }
}
