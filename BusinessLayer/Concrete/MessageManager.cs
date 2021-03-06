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
    public class MessageManager:IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(t => t.MessageID == id);
        }



        public void MessageAddBL(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetListInbox()
        {
            return _messageDal.List(t => t.ReceiverMail == "admin@gmail.com");
        }

        public List<Message> GetListSendbox()
        {
            return _messageDal.List(t => t.SenderMail == "admin@gmail.com");
        }
    }
}
