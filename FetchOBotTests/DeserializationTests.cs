namespace FetchOBotApiTests
{
    using System;
    using FetchOBotApi;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;

    [TestClass]
    public class DeserializationTests
    {
        [TestMethod]
        public void DeserializeHistoryPage()
        {
            const string json = @"{ ""history"" : [{}, {}], ""meta"": {} }";
            var result = JsonConvert.DeserializeObject<HistoryPage>(json);
            Assert.AreEqual(2, result.History.Length);
            Assert.IsNotNull(result.Meta);
        }
    }
}
