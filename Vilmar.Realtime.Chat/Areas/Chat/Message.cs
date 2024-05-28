namespace Vilmar.Realtime.Chat.Areas.Chat
{
    public class Message
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
    }
}
