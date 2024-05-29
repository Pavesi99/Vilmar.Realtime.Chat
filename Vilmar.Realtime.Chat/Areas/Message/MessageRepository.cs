using Vilmar.Realtime.Chat.Areas.Context;
using Vilmar.Realtime.Chat.Areas.Generic;

namespace Vilmar.Realtime.Chat.Areas.Message
{
    public class MessageRepository : GenericRepository<MessageModel>, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
