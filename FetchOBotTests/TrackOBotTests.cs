namespace FetchOBotApiTests
{
    using System;
    using FetchOBotApi;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TrackOBotTests
    {
        private const string ResponseJson =
            @"{
                ""history"" : [{}, {}],
                ""meta"": {}
            }";

        [TestMethod]
        public void TestGetHistoryPageAsync()
        {
            var webClient = new MockWebClient { ResponseString = ResponseJson };
            var trackOBot = new TrackOBot(webClient);
            var result = trackOBot.GetHistoryPageAsync("testUsername", "testApiToken", 2).Result;

            Assert.AreEqual("https://trackobot.com/profile/history.json?username=testUsername&token=testApiToken&page=2", webClient.LastUrl);
            Assert.AreEqual(2, result.History.Length);
            Assert.IsNotNull(result.Meta);
        }

        [TestMethod]
        public void TestRequestCount()
        {
            var webClient = new MockWebClient { ResponseString = ResponseJson };
            var trackOBot = new TrackOBot(webClient);

            Assert.AreEqual(0, trackOBot.RequestCount);
            trackOBot.GetHistoryPageAsync("testUsername", "testApiToken", 2).Wait();
            trackOBot.GetHistoryPageAsync("testUsername", "testApiToken", 2).Wait();

            Assert.AreEqual(2, trackOBot.RequestCount);
        }

        [TestMethod]
        public void TestGetHistoryParseError()
        {
            var webClient = new MockWebClient
            {
                ResponseString =
                    @"{
                        ""history"" : 1
                    }"
            };

            var trackOBot = new TrackOBot(webClient);
            AggregateException caughtException = null;

            try
            {
                var result = trackOBot.GetHistoryPageAsync("testUsername", "testApiToken", 2).Result;
            }
            catch(AggregateException ex)
            {
                caughtException = ex;
            }

            Assert.IsNotNull(caughtException);
            Assert.IsTrue(caughtException.InnerException is FetchOBotParseException);
            Assert.AreEqual(webClient.ResponseString, ((FetchOBotParseException)caughtException.InnerException).ResponseBody);
        }
    }
}
