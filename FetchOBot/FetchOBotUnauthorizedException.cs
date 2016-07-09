﻿namespace FetchOBotApi
{
    using System;

    /// <summary>
    /// Exception indicating that the supplied Track-o-bot credentials are invalid
    /// </summary>
    public class FetchOBotUnauthorizedException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FetchOBotUnauthorizedException()
            : base("The supplied Track-o-bot credentials are invalid.")
        {
        }
    }
}
