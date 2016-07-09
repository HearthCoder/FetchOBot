namespace FetchOBotApiTests
{
    using System;
    using FetchOBotApi;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TrackOBotTests
    {
        [TestMethod]
        public void TestGetHistoryAsync()
        {
            var webClient = new MockWebClient
            {
                ResponseString =
                    @"{
                        ""history"" : [{}, {}],
                        ""meta"": {}
                    }"
            };

            var trackOBot = new TrackOBot(webClient);
            var result = trackOBot.GetHistoryAsync("testUsername", "testApiToken", 2).Result;

            Assert.AreEqual("https://trackobot.com/profile/history.json?username=testUsername&token=testApiToken&page=2", webClient.LastUrl);
            Assert.AreEqual(2, result.History.Length);
            Assert.IsNotNull(result.Meta);
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
                var result = trackOBot.GetHistoryAsync("testUsername", "testApiToken", 2).Result;
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
