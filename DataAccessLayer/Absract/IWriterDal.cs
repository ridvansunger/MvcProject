using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Absract
{
    using EntityLayer.Concrete;
    public interface IWriterDal:IRepository<Writer>
    {
    }
}
