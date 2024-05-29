using Vilmar.Realtime.Chat.Areas.Message;

namespace Vilmar.Realtime.Chat.Tests
{
    public class MessageUnitTest
    {
        [Fact]
        public void CheckIfMessageIsStockCall()
        {
            var message = new MessageModel() { Text = "/stock=aapl.us" };

            Assert.True(message.IsStockCall());
        }

        [Fact]
        public void CheckIfMessageIsNotStockCall()
        {
            var message = new MessageModel() { Text = "/get=aapl.us" };

            Assert.False(message.IsStockCall());
        }

        [Fact]
        public void CanGetStock()
        {
            var message = new MessageModel() { Text = "/stock=aapl.us" };

            Assert.Equal("aapl.us", message.GetStock());
        }
    }
}