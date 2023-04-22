using SamoLetoAPI.DTO;
using System.Collections.Concurrent;

namespace SamoLetoAPI.Singleton
{
    public class SharedDictionary : ISharedDictionary
    {
        private SemaphoreSlim semaphore = new SemaphoreSlim(1);
        private static readonly ConcurrentDictionary<string, int> flightTicketsDict = new ConcurrentDictionary<string, int>
        {
            ["Flight 77"] = 58,
            ["Flight 11"] = 81,
            ["Flight 175"] = 56
        };

        //public ConcurrentDictionary<string, int> FlightTicketsDict => flightTicketsDict;

        public async Task<BaseResponseDTO> ReserveSeat(string flightNumber)
        {
            try
            {
                semaphore.Wait();
                int availableTickets;
                if (flightTicketsDict.TryGetValue(flightNumber, out availableTickets) && availableTickets > 0)
                {
                    flightTicketsDict[flightNumber]--;
                    return new(ErrorCode.OK);
                }
                return new(ErrorCode.NoTicketsAvailable);
            }
            catch (Exception ex)
            {
                return new(ErrorCode.DefaultError);
            }
            finally 
            { 
                semaphore.Release(); 
            }
            
        }
    }
}
