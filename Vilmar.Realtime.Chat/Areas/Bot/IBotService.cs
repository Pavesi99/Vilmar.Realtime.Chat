namespace Vilmar.Realtime.Chat.Areas.Bot
{
    public interface IBotService
    {
        bool VerifyQuote(string quote);
        bool IsStockCall(string command);
        bool VerifyCommand(string command);
        Task SendStock(string stockName);
        Task<string> GetQuote(string stockName);
    }
}
