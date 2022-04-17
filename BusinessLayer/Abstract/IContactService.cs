using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        //ilk başta burada tanımla içini managerde doldur.
        List<Contact> GetList();

        void ContactAddBL(Contact contact);

        //id ye göre işlem yap
        Contact GetByID(int id);

        //silme işlemi
        void ContactDelete(Contact contact);

        //güncelleme
        void ContactUpdate(Contact contact);
    }
}
