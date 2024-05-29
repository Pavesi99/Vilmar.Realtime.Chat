
namespace Vilmar.Realtime.Chat.Areas.Message
{
    public class MessageModel
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public DateTime PostedData { get; set; } = DateTime.UtcNow;

        public bool IsStockCall() => string.Compare(Text, 0, "/stock=", 0, 7) == 0;
        public bool IsCall() => string.Compare(Text, 0, "/", 0, 1) == 0;

        public string GetStock() => Text.Substring(7);
    }
}
