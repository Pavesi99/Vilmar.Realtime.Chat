
namespace Vilmar.Realtime.Chat.Areas.Message
{
    public class MessageModel
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public DateTime PostedData { get; set; } = DateTime.UtcNow;
    }
}
