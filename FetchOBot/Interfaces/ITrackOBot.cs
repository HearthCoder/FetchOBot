namespace FetchOBotApi
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for TrackOBot
    /// </summary>
    internal interface ITrackOBot
    {
        /// <summary>
        /// Load a single page of the user's game history
        /// </summary>
        /// <param name="username">Track-o-bot username</param>
        /// <param name="apiToken">API token</param>
        /// <param name="page">Page</param>
        /// <returns>Game history</returns>
        Task<HistoryPage> GetHistoryPageAsync(string username, string apiToken, int page);
    }
}
