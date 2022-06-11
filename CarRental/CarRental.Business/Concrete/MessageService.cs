using CarRental.Business.Abstract;
using CarRental.Core.Business.Concrete;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;

namespace CarRental.Business.Concrete
{
    public class MessageService : CoreService<Message, IMessageDal>, IMessageService
    {
        public MessageService(IMessageDal messageDal) : base(messageDal)
        {
        }
    }
}