namespace Binance.Spot.WalletExamples
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Common;
    using Binance.Spot;
    using Binance.Spot.Models;
    using Microsoft.Extensions.Logging;

    public class QueryUserUniversalTransferHistory_Example
    {
        public static async Task Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<QueryUserUniversalTransferHistory_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger: logger);
            HttpClient httpClient = new HttpClient(handler: loggingHandler);

            var wallet = new Wallet(httpClient);

            var result = await wallet.QueryUserUniversalTransferHistory(UniversalTransferType.MAIN_C2C);
        }
    }
}