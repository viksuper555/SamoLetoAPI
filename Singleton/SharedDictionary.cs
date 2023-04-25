using SamoLetoAPI.DTO;
using System.Collections.Concurrent;

namespace SamoLetoAPI.Singleton
{
    public class SharedDictionary : ISharedDictionary
    {
        private ConcurrentDictionary<string, SemaphoreSlim> flightsemaphores = new ConcurrentDictionary<string, SemaphoreSlim>
        {
            ["Flight 77"] = new SemaphoreSlim(1),
            ["Flight 11"] = new SemaphoreSlim(1),
            ["Flight 175"] = new SemaphoreSlim(1)
        };
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

                SemaphoreSlim semaphore = null;
                if (flightsemaphores.TryGetValue(flightNumber, out semaphore ) && semaphore != null) 
                {
                    semaphore.Wait();
                    int availableTickets;
                    if (flightTicketsDict.TryGetValue(flightNumber, out availableTickets) && availableTickets > 0)
                    {
                        flightTicketsDict[flightNumber]--;
                        semaphore.Wait(5000);
                        semaphore.Release();
                        return new(ErrorCode.OK);
                    }
                    semaphore.Release();
                    return new(ErrorCode.NoTicketsAvailable);
                }
            }
            catch (Exception ex)
            {

            }
            return new(ErrorCode.DefaultError);

        }
    }
}
