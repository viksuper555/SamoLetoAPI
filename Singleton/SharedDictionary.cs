using System.Collections.Concurrent;

namespace SamoLetoAPI.Singleton
{
    public class SharedDictionary : ISharedDictionary
    {
        private static readonly ConcurrentDictionary<string, string> availableTickets = new ConcurrentDictionary<string, string>();

        public ConcurrentDictionary<string, string> AvailableTickets => availableTickets;
    }
}
