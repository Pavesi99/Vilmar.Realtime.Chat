﻿using MassTransit;

namespace Vilmar.Realtime.Chat.Areas.Message
{
    public class MessageConsumer : IConsumer<IMessageCreated>
    {
        private readonly MessageRepository messageRepository;

        public MessageConsumer(MessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        public async Task Consume(ConsumeContext<IMessageCreated> context)
        {
            Console.WriteLine("Stock -> " + context.Message);
            await messageRepository.Add(new MessageModel() { ChatId = 0, PostedData = DateTime.UtcNow, Text = context.Message.MessageText, UserId = "bot" });
        }
    }
}
