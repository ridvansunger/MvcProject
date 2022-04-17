using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public  interface IHeadingService
    {
        List<Heading> GetList();

        void HeadingAddBL(Heading heading );

        //id ye göre işlem yap
        Heading GetByID(int id);

        //silme işlemi
        void HeadingDelete(Heading heading);

        //güncelleme
        void HeadingUpdate(Heading heading);
    }
}
