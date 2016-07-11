namespace FetchOBotApi
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Mock implementation of ITrackOBot
    /// </summary>
    public class MockTrackOBot : ITrackOBot
    {
        private int currentPage = 0;

        /// <summary>
        /// Constructor
        /// </summary>
        public MockTrackOBot()
        {
            this.PagesRequested = new List<int>();
        }

        /// <summary>
        /// HistoryPages to return
        /// </summary>
        public HistoryPage[] ReturnValues { get; set; }

        /// <summary>
        /// Last seen username
        /// </summary>
        public string LastUsername { get; private set; }

        /// <summary>
        /// Last seen API token
        /// </summary>
        public string LastApiToken { get; private set; }

        /// <summary>
        /// Pages requested
        /// </summary>
        public List<int> PagesRequested { get; private set; }

        /// <summary>
        /// Load a single page of the user's game history
        /// </summary>
        /// <param name="username">Track-o-bot username</param>
        /// <param name="apiToken">API token</param>
        /// <param name="page">Page</param>
        /// <returns>Game history</returns>
        public Task<HistoryPage> GetHistoryAsync(string username, string apiToken, int page)
        {
            this.LastUsername = username;
            this.LastApiToken = apiToken;
            this.PagesRequested.Add(page);
            return Task.FromResult(this.ReturnValues[this.currentPage++]);
        }
    }
}
