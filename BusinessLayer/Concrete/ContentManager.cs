using BusinessLayer.Abstract;
using DataAccessLayer.Absract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContectDal _contectDal;

        public ContentManager(IContectDal contectDal)
        {
            _contectDal = contectDal;
        }

        public void ContentAddBL(Content content)
        {
            _contectDal.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            _contectDal.Delete(content);
        }

        public void ContentUpdate(Content content)
        {
            _contectDal.Update(content);
        }

        public Content GetByID(int id)
        {
            return _contectDal.Get(t => t.ContentID == id);
        }

        public List<Content> GetList()
        {
            return _contectDal.List();
        }


        //id paremetresine göre içerik getirecek
        public List<Content> GetListByHeadingID(int id)
        {
            return _contectDal.List(t => t.HeadingID == id);
        }
    }
}
