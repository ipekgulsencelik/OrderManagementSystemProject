using OrderManagement.Business.Abstract;
using OrderManagement.DataAccess.Abstract;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Concrete
{
    public class MessageManager : GenericManager<Message>, IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageManager(IRepository<Message> _repository, IMessageRepository messageRepository) : base(_repository)
        {
            _messageRepository = messageRepository;
        }
    }
}