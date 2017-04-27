namespace FetchOBotApi
{
    using System;

    /// <summary>
    /// Exception thrown when there was an error communicating with the Track-o-bot server
    /// </summary>
    public class FetchOBotUnavailableException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="innerException">Inner exception</param>
        internal FetchOBotUnavailableException(Exception innerException)
            : base("There was an error communicating with the Track-o-bot server.", innerException)
        {
        }
    }
}
