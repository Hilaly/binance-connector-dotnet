namespace Binance.Spot.Tests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using Binance.Spot.Models;
    using Moq;
    using Moq.Protected;
    using Xunit;

    public class UserDataStreams_Tests
    {
        private string apiKey = "vmPUZE6mv9SD5VNHk4HlWFsOr6aKE2zvsw0MuIgwCIPy6utIco14y7Ju91duEh8A";
        private string apiSecret = "NhqPtmdSJYdKjVHjA7PZj4Mge3R5YNiP1e3UZjInClVN65XAbvqqM6A7H5fATj0j";

        #region CreateSpotListenKey
        [Fact]
        public async void CreateSpotListenKey_Response()
        {
            var responseContent = "{\"listenKey\":\"pqia91ma19a5s61cv6a81va65sdf19v8a65a1a5s61cv6a81va65sdf19v8a65a1\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/userDataStream", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            UserDataStreams userDataStreams = new UserDataStreams(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await userDataStreams.CreateSpotListenKey();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region PingSpotListenKey
        [Fact]
        public async void PingSpotListenKey_Response()
        {
            var responseContent = "{}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/userDataStream", HttpMethod.Put)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            UserDataStreams userDataStreams = new UserDataStreams(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await userDataStreams.PingSpotListenKey("pqia91ma19a5s61cv6a81va65sdf19v8a65a1a5s61cv6a81va65sdf19v8a65a1");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CloseSpotListenKey
        [Fact]
        public async void CloseSpotListenKey_Response()
        {
            var responseContent = "{}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/userDataStream", HttpMethod.Delete)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            UserDataStreams userDataStreams = new UserDataStreams(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await userDataStreams.CloseSpotListenKey("pqia91ma19a5s61cv6a81va65sdf19v8a65a1a5s61cv6a81va65sdf19v8a65a1");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CreateMarginListenKey
        [Fact]
        public async void CreateMarginListenKey_Response()
        {
            var responseContent = "{\"listenKey\":\"T3ee22BIYuWqmvne0HNq2A2WsFlEtLhvWCtItw6ffhhdmjifQ2tRbuKkTHhr\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/userDataStream", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            UserDataStreams userDataStreams = new UserDataStreams(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await userDataStreams.CreateMarginListenKey();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region PingMarginListenKey
        [Fact]
        public async void PingMarginListenKey_Response()
        {
            var responseContent = "{}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/userDataStream", HttpMethod.Put)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            UserDataStreams userDataStreams = new UserDataStreams(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await userDataStreams.PingMarginListenKey("T3ee22BIYuWqmvne0HNq2A2WsFlEtLhvWCtItw6ffhhdmjifQ2tRbuKkTHhr");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CloseMarginListenKey
        [Fact]
        public async void CloseMarginListenKey_Response()
        {
            var responseContent = "{}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/userDataStream", HttpMethod.Delete)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            UserDataStreams userDataStreams = new UserDataStreams(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await userDataStreams.CloseMarginListenKey("T3ee22BIYuWqmvne0HNq2A2WsFlEtLhvWCtItw6ffhhdmjifQ2tRbuKkTHhr");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CreateIsolatedMarginListenKey
        [Fact]
        public async void CreateIsolatedMarginListenKey_Response()
        {
            var responseContent = "{\"listenKey\":\"T3ee22BIYuWqmvne0HNq2A2WsFlEtLhvWCtItw6ffhhdmjifQ2tRbuKkTHhr\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/userDataStream/isolated", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            UserDataStreams userDataStreams = new UserDataStreams(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await userDataStreams.CreateIsolatedMarginListenKey();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region PingIsolatedMarginListenKey
        [Fact]
        public async void PingIsolatedMarginListenKey_Response()
        {
            var responseContent = "{}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/userDataStream/isolated", HttpMethod.Put)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            UserDataStreams userDataStreams = new UserDataStreams(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await userDataStreams.PingIsolatedMarginListenKey("T3ee22BIYuWqmvne0HNq2A2WsFlEtLhvWCtItw6ffhhdmjifQ2tRbuKkTHhr");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CloseIsolatedMarginListenKey
        [Fact]
        public async void CloseIsolatedMarginListenKey_Response()
        {
            var responseContent = "{}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/userDataStream/isolated", HttpMethod.Delete)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            UserDataStreams userDataStreams = new UserDataStreams(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await userDataStreams.CloseIsolatedMarginListenKey("T3ee22BIYuWqmvne0HNq2A2WsFlEtLhvWCtItw6ffhhdmjifQ2tRbuKkTHhr");

            Assert.Equal(responseContent, result);
        }
        #endregion
    }
}