using Vilmar.Realtime.Chat.Areas.Generic;
using Vilmar.Realtime.Chat.Context;

namespace Vilmar.Realtime.Chat.Areas.Message
{
    public class MessageRepository : GenericRepository<MessageModel>, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
