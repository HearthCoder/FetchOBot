namespace FetchOBotApi
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Accumulator of a range of game history
    /// </summary>
    internal class HistoryAccumulator
    {
        private ITrackOBot trackOBot;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="trackOBot">TrackOBot instance</param>
        public HistoryAccumulator(ITrackOBot trackOBot)
        {
            this.trackOBot = trackOBot;
        }

        /// <summary>
        /// Asynchronously loads a the user's game history up to a given game ID or start time, whichever is encountered first
        /// </summary>
        /// <param name="username">Track-o-bot username</param>
        /// <param name="apiToken">API token</param>
        /// <param name="gameId">Game ID</param>
        /// <param name="rangeStart">Range start</param>
        /// <returns>Array of games</returns>
        public async Task<Game[]> GetHistoryRangeAsync(string username, string apiToken, int? gameId, DateTime? rangeStart)
        {
            var history = new List<Game>();
            int page = 1;
            bool done = false;
            var gameIds = new HashSet<long>();

            while (!done)
            {
                // Load and process the next history page
                var historyPage = await this.trackOBot.GetHistoryPageAsync(username, apiToken, page);
                foreach (Game game in historyPage.History)
                {
                    // See if we've hit the end of the range
                    if (game.Id == gameId || rangeStart != null && game.Added < rangeStart)
                    {
                        done = true;
                        break;
                    }

                    // If we've already included this game, don't include it again
                    if (!gameIds.Contains(game.Id))
                    {
                        // Include the game
                        history.Add(game);
                        gameIds.Add(game.Id);
                    }
                }

                // Check if this was the last page
                done |= (historyPage.Meta.NextPage == null);

                // Move to the next page
                page++;
            }

            // Return the accumulated history
            return history.ToArray();
        }
    }
}
