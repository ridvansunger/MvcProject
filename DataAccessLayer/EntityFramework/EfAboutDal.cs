using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    using Concrete.Repositories;
    using Absract;
    using EntityLayer.Concrete;

    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
    }
}
