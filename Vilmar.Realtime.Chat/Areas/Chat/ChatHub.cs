using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using Vilmar.Realtime.Chat.Areas.Message;

namespace Vilmar.Realtime.Chat.Areas.Chat
{
    public class ChatHub : Hub
    {
        private readonly MessageRepository messageRepository;

        public ChatHub(MessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }
        public async IAsyncEnumerable<IEnumerable<MessageModel>> Streaming(CancellationToken cancellationToken)
        {
            while (true)
            {
                yield return  messageRepository.Get(orderBy: x => x.OrderBy(y => y.PostedData),limit: 50).OrderByDescending(x => x.PostedData);
                await Task.Delay(1000, cancellationToken);
            }
        }
    }
}
