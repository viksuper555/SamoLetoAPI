using System.Collections.Concurrent;

namespace SamoLetoAPI.Singleton
{
    public interface ISharedDictionary
    {
        ConcurrentDictionary<string, string> AvailableTickets { get; }
    }
}
