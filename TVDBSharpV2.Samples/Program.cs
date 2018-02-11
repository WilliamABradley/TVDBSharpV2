using System;
using System.Linq;
using System.Threading.Tasks;
using TVDBSharp.Models;
using TVDBSharp.Models.Requests;
using WAConsoleHelpers;

namespace TVDBSharp.Samples
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            ConsoleHelpers.SystemWriteLine("Welcome to TVDBSharpV2 Sample App\nSetting up TVDBManager...");

            var client = new TVDBManager();

            TVDBJwtToken Token = null;

            while (Token == null)
            {
                ConsoleHelpers.SystemWrite("\nPlease enter your API Key: ");
                var key = Console.ReadLine();

                try
                {
                    Token = await client.Authentication.GetJwtToken(new CredentialPacket(key));
                }
                catch (Exception ex)
                {
                    ConsoleHelpers.PrintProperty("Failed", ex);
                }
            }

            client.Authenticate(Token.Token);

            ConsoleHelpers.PrintProperty("Token", Token);

            while (true)
            {
                try
                {
                    ConsoleHelpers.SystemWrite("\nSearch for a Show: (Press Enter to Exit)");
                    var query = Console.ReadLine();

                    // Get me out of here!
                    if (string.IsNullOrWhiteSpace(query))
                    {
                        break;
                    }

                    ConsoleHelpers.PrintProperty("Searching TVDB for", query);
                    var series = await client.Series.FindSeries(query);
                    ConsoleHelpers.PrintProperty("\nResult", series);

                    if (series.Any())
                    {
                        var id = series.First().ID;
                        ConsoleHelpers.PrintProperty("\nGetting full information for", id);

                        var fullSeries = await client.Series.GetSeries(id, true);

                        ConsoleHelpers.PrintProperty("\nResult", fullSeries);
                    }
                }
                catch (Exception ex)
                {
                    ConsoleHelpers.PrintProperty("Failed", ex);
                }
            }

            ConsoleHelpers.AnyKeyContinue();
        }
    }
}