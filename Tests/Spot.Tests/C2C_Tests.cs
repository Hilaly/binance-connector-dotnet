namespace Binance.Spot.Tests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using Binance.Spot.Models;
    using Moq;
    using Moq.Protected;
    using Xunit;

    public class C2C_Tests
    {
        private string apiKey = "vmPUZE6mv9SD5VNHk4HlWFsOr6aKE2zvsw0MuIgwCIPy6utIco14y7Ju91duEh8A";
        private string apiSecret = "NhqPtmdSJYdKjVHjA7PZj4Mge3R5YNiP1e3UZjInClVN65XAbvqqM6A7H5fATj0j";

        #region GetC2cTradeHistory
        [Fact]
        public async void GetC2cTradeHistory_Response()
        {
            var responseContent = "{\"code\":\"000000\",\"message\":\"success\",\"data\":[{\"orderNumber\":\"20219644646554779648\",\"advNo\":\"11218246497340923904\",\"tradeType\":\"SELL\",\"asset\":\"BUSD\",\"fiat\":\"CNY\",\"fiatSymbol\":\"￥\",\"amount\":\"5000.00000000\",\"totalPrice\":\"33400.00000000\",\"unitPrice\":\"6.68\",\"orderStatus\":\"COMPLETED\",\"createTime\":1619361369000,\"commission\":\"0\",\"counterPartNickName\":\"ab***\",\"advertisementRole\":\"TAKER\"}],\"total\":1,\"success\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/c2c/orderMatch/listUserOrderHistory", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            C2C c2C = new C2C(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await c2C.GetC2cTradeHistory(Side.BUY);

            Assert.Equal(responseContent, result);
        }
        #endregion
    }
}