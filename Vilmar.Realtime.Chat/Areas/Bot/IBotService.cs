namespace Vilmar.Realtime.Chat.Areas.Bot
{
    public interface IBotService
    {
        bool VerifyQuote(string quote);
        Task SendStock(string stockName);
        Task<string> GetQuote(string stockName);
    }
}
