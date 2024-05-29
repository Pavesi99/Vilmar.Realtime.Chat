﻿using CsvHelper;
using MassTransit;
using System;
using System.Formats.Asn1;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using Vilmar.Realtime.Chat.Areas.Message;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace Vilmar.Realtime.Chat.Areas.Bot
{
    public class BotService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IPublishEndpoint publishEndpoint;

        public BotService(IHttpClientFactory httpClientFactory, IPublishEndpoint publishEndpoint)
        {
            this.httpClientFactory = httpClientFactory;
            this.publishEndpoint = publishEndpoint;
        }

        private bool VerifyQuote(string quote) => !quote.Contains("N/D");
        private  bool IsStockCall(string command) => string.Compare(command, 0, "/stock=", 0, 7) == 0;

        public bool VerifyCommand(string command)
        {
            return IsStockCall(command);
        }
        public async Task SendStock(string stockName)
        {
            var quote = await GetQuote(stockName);
            var stockMessage = VerifyQuote(quote) ? $"{stockName} quote is ${quote} per share" : $"Stock code \"{stockName}\" not found";
            await publishEndpoint.Publish<IMessageCreated>(new { MessageDate = DateTime.UtcNow, MessageText = stockMessage });
        }

        public async Task<string> GetQuote(string stockName)
        {
            using var httpClient = httpClientFactory.CreateClient("stooq");
            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}/?s={stockName}&f=sd2t2ohlcv&h&e=csv");

             var contentString =
                await httpResponseMessage.Content.ReadAsStringAsync();

            var quote = contentString.Split(',')[13];
            return quote;
        }
    }
}