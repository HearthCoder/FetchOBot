namespace FetchOBotApiTests
{
    using System;
    using FetchOBotApi;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;

    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void DeserializeCard()
        {
            const string json =
                @"{
                    ""id"": ""Test ID"",
                    ""name"": ""Test Name"",
                    ""mana"": 2
                }";

            var result = JsonConvert.DeserializeObject<Card>(json);
            Assert.AreEqual("Test ID", result.Id);
            Assert.AreEqual("Test Name", result.Name);
            Assert.AreEqual(2, result.Mana);
        }

        [TestMethod]
        public void DeserializeCardWithNullValues()
        {
            const string json =
                @"{
                    ""mana"": null
                }";

            var result = JsonConvert.DeserializeObject<Card>(json);
            Assert.AreEqual(null, result.Mana);
        }

        [TestMethod]
        public void DeserializeCardPlayed()
        {
            const string json =
                @"{
                    ""player"": ""opponent"",
                    ""turn"": 2,
                    ""card"": {}
                }";

            var result = JsonConvert.DeserializeObject<CardPlayed>(json);
            Assert.AreEqual(Player.Opponent, result.Player);
            Assert.AreEqual(2, result.Turn);
            Assert.IsNotNull(result.Card);
        }

        [TestMethod]
        public void DeserializeGame()
        {
            const string json =
                @"{
                    ""id"" : 1234,
                    ""mode"" : ""ranked"",
                    ""hero"" : ""Paladin"",
                    ""hero_deck"": ""Test hero deck"",
                    ""opponent"": ""Rogue"",
                    ""opponent_deck"": ""Test opponent deck"",
                    ""coin"": true,
                    ""result"": ""win"",
                    ""duration"": 361,
                    ""rank"": 23,
                    ""legend"": 19,
                    ""note"": ""Test note"",
                    ""added"": ""2016-07-05T16:01:59.000Z""
                }";

            var result = JsonConvert.DeserializeObject<Game>(json);
            Assert.AreEqual(1234, result.Id);
            Assert.AreEqual(Mode.Ranked, result.Mode);
            Assert.AreEqual(Hero.Paladin, result.Hero);
            Assert.AreEqual("Test hero deck", result.HeroDeck);
            Assert.AreEqual(Hero.Rogue, result.Opponent);
            Assert.AreEqual("Test opponent deck", result.OpponentDeck);
            Assert.AreEqual(true, result.Coin);
            Assert.AreEqual(Result.Win, result.Result);
            Assert.AreEqual(361, result.Duration);
            Assert.AreEqual(23, result.Rank);
            Assert.AreEqual(19, result.Legend);
            Assert.AreEqual("Test note", result.Note);
            Assert.AreEqual(TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse("2016-07-05T16:01:59.000Z")), result.Added);
        }

        [TestMethod]
        public void DeserializeGameWithNullValues()
        {
            const string json =
                @"{
                    ""hero_deck"": null,
                    ""opponent_deck"": null,
                    ""duration"": null,
                    ""rank"": null,
                    ""legend"": null,
                    ""note"": null
                }";

            var result = JsonConvert.DeserializeObject<Game>(json);
            Assert.AreEqual(null, result.HeroDeck);
            Assert.AreEqual(null, result.OpponentDeck);
            Assert.AreEqual(null, result.Duration);
            Assert.AreEqual(null, result.Rank);
            Assert.AreEqual(null, result.Legend);
            Assert.AreEqual(null, result.Note);
        }

        [TestMethod]
        public void DeserializeHistoryPage()
        {
            const string json =
                @"{
                    ""history"" : [{}, {}],
                    ""meta"": {}
                }";

            var result = JsonConvert.DeserializeObject<HistoryPage>(json);
            Assert.AreEqual(2, result.History.Length);
            Assert.IsNotNull(result.Meta);
        }

        [TestMethod]
        public void DeserializePageInfo()
        {
            const string json =
                @"{
                    ""current_page"" : 2,
                    ""next_page"" : 3,
                    ""prev_page"" : 1,
                    ""total_pages"" : 4,
                    ""total_items"" : 5,
                }";

            var result = JsonConvert.DeserializeObject<PageInfo>(json);
            Assert.AreEqual(2, result.CurrentPage);
            Assert.AreEqual(3, result.NextPage);
            Assert.AreEqual(1, result.PreviousPage);
            Assert.AreEqual(4, result.TotalPages);
            Assert.AreEqual(5, result.TotalItems);
        }

        [TestMethod]
        public void DeserializePageInfoWithNullValues()
        {
            const string json = @"{ ""prev_page"" : null }";
            var result = JsonConvert.DeserializeObject<PageInfo>(json);
            Assert.AreEqual(null, result.PreviousPage);
        }
    }
}
