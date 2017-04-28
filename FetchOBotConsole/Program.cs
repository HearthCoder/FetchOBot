namespace FetchOBotConsole
{
    using System;
    using FetchOBotApi;

    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.Write("Username: ");
                var username = Console.ReadLine();

                Console.Write("API token: ");
                var apiToken = Console.ReadLine();

                var fetchOBot = new FetchOBot();
                var history = fetchOBot.GetHistoryRangeAsync(username, apiToken, DateTime.UtcNow.AddDays(-14)).Result;
                Console.WriteLine("Done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }
    }
}
