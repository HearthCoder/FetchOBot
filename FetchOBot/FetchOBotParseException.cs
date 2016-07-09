namespace FetchOBotApi
{
    using System;

    /// <summary>
    /// Exception thrown when there was an error parsing the Track-o-bot response
    /// </summary>
    public class FetchOBotParseException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="innerException">Inner exception</param>
        /// <param name="responseBody">Response body</param>
        internal FetchOBotParseException(Exception innerException, string responseBody)
            : base("There was an error parsing the Track-o-bot response.", innerException)
        {
            this.ResponseBody = responseBody;
        }

        /// <summary>
        /// Response body
        /// </summary>
        public string ResponseBody
        {
            get;
            private set;
        }
    }
}
