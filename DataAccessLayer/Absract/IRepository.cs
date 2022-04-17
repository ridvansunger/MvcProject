using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Absract
{
    public interface IRepository<T>
    {
        List<T> List();

        void Insert(T item);
        void Update(T item);
        void Delete(T item);

        //ID bulma işlemi, tek değer döndürmek için kullanılacak
        T Get(Expression<Func<T, bool>> filter);


        //filtre işlemleri için kullanılacak, liste şeklinde döner
        List<T> List(Expression<Func<T, bool>> filter);
    }
}
