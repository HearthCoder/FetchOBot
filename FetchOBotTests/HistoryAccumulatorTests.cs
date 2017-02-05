namespace FetchOBotApiTests
{
    using System;
    using FetchOBotApi;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HistoryAccumulatorTests
    {
        [TestMethod]
        public void TestLoadUntilLastPage()
        {
            var trackOBot = this.InitializeMock(1);
            var historyAccumulator = new HistoryAccumulator(trackOBot);
            var history = historyAccumulator.GetHistoryRangeAsync(null, null, null, null).Result;
            Assert.AreEqual(2, history.Length); // One page has 2 games
        }

        [TestMethod]
        public void TestCredentialsPassed()
        {
            var trackOBot = this.InitializeMock(1);
            var historyAccumulator = new HistoryAccumulator(trackOBot);
            var history = historyAccumulator.GetHistoryRangeAsync("testUsername", "testApiToken", null, null).Result;
            Assert.AreEqual("testUsername", trackOBot.LastUsername);
            Assert.AreEqual("testApiToken", trackOBot.LastApiToken);
        }

        [TestMethod]
        public void TestLoadsPagesInOrder()
        {
            var trackOBot = this.InitializeMock(3);
            var historyAccumulator = new HistoryAccumulator(trackOBot);
            var history = historyAccumulator.GetHistoryRangeAsync(null, null, null, null).Result;
            Assert.AreEqual(3, trackOBot.PagesRequested.Count);
            Assert.AreEqual(1, trackOBot.PagesRequested[0]);
            Assert.AreEqual(2, trackOBot.PagesRequested[1]);
            Assert.AreEqual(3, trackOBot.PagesRequested[2]);
        }

        [TestMethod]
        public void TestLoadUntilGameId()
        {
            var trackOBot = this.InitializeMock(3);
            trackOBot.ReturnValues[1].History[1].Id = 123;
            var historyAccumulator = new HistoryAccumulator(trackOBot);
            var history = historyAccumulator.GetHistoryRangeAsync(null, null, 123, null).Result;
            Assert.AreEqual(3, history.Length); // First page plus first game on the second page
        }

        [TestMethod]
        public void TestLoadUntilTime()
        {
            var trackOBot = this.InitializeMock(3);
            trackOBot.ReturnValues[0].History[0].Added = new DateTime(2016, 6, 8);
            trackOBot.ReturnValues[0].History[1].Added = new DateTime(2016, 6, 6);
            trackOBot.ReturnValues[1].History[0].Added = new DateTime(2016, 6, 4);
            trackOBot.ReturnValues[1].History[1].Added = new DateTime(2016, 6, 2);
            var historyAccumulator = new HistoryAccumulator(trackOBot);
            var history = historyAccumulator.GetHistoryRangeAsync(null, null, null, new DateTime(2016, 6, 3)).Result;
            Assert.AreEqual(3, history.Length); // First page plus first game on the second page
        }

        [TestMethod]
        public void TestDuplicatedGames()
        {
            var trackOBot = this.InitializeMock(3);
            trackOBot.ReturnValues[0].History[1].Id = 100;
            trackOBot.ReturnValues[1].History[0].Id = 100;
            trackOBot.ReturnValues[2].History[1].Id = 101;
            var historyAccumulator = new HistoryAccumulator(trackOBot);
            var history = historyAccumulator.GetHistoryRangeAsync(null, null, 101, null).Result;
            Assert.AreEqual(4, history.Length);
        }

        /// <summary>
        /// Initialize the MockTrackOBot
        /// </summary>
        /// <param name="pageCount">Number of history pages</param>
        private MockTrackOBot InitializeMock(int pageCount)
        {
            long id = 0;
            var historyPages = new HistoryPage[pageCount];
            for (int i = 0; i < pageCount; i++)
            {
                historyPages[i] = new HistoryPage
                {
                    // Each page has 2 games in it
                    History = new Game[] {
                        new Game { Id = id++ },
                        new Game { Id = id++ }
                    },
                    Meta = new PageInfo
                    {
                        CurrentPage = i + 1,
                        NextPage = i + 2
                    }
                };
            }

            historyPages[pageCount - 1].Meta.NextPage = null;
            return new MockTrackOBot
            {
                ReturnValues = historyPages
            };
        }
    }
}
