using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    using Absract;
    using EntityLayer.Concrete;
    using System.Data.Entity;

    public class CategoryRepository : ICategoryDal
    {
        Context db = new Context();
        DbSet<Category> _object;

        public void Delete(Category p)
        {
            _object.Remove(p);
            db.SaveChanges();
        }

        public void Insert(Category p)
        {
            _object.Add(p);
            db.SaveChanges();
        }

        public List<Category> List()
        {
            return _object.ToList();
        }

        public void Update(Category p)
        {
            db.SaveChanges();
        }
    }
}
