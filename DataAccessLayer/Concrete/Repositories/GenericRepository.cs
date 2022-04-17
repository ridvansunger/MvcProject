using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    using Absract;
    using System.Data.Entity;
    using System.Linq.Expressions;

    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context db = new Context();
        DbSet<T> _object;


        public GenericRepository()
        {
            _object = db.Set<T>();
        }


        public void Delete(T item)
        {
            var detetedEntity = db.Entry(item);
            detetedEntity.State = EntityState.Deleted;
            //_object.Remove(item);
            db.SaveChanges();
        }


        //id bulacak
        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T item)
        {

            var addedEntity = db.Entry(item);
            addedEntity.State = EntityState.Added;
            //_object.Add(item);
            db.SaveChanges();

        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T item)
        {
            var updatedEntity = db.Entry(item);
            updatedEntity.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
