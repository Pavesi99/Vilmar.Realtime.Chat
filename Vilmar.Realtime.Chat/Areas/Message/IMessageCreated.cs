namespace Vilmar.Realtime.Chat.Areas.Message
{
    public interface IMessageCreated
    {
        DateTime MessageDate { get; }
        string MessageText { get; }
    }
}
