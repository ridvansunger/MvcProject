
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    using DataAccessLayer.Absract;
    using DataAccessLayer.Concrete.Repositories;
    using EntityLayer.Concrete;

    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
    }
}
