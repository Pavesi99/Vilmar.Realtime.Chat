using Vilmar.Realtime.Chat.Context;
using WebApi.Molde.Infra.Repository;

namespace Vilmar.Realtime.Chat.Areas.Message
{
    public class MessageRepository : GenericRepository<MessageModel>
    {
        public MessageRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
