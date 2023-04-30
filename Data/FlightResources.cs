using SamoLetoAPI.DTO;
using SamoLetoAPI.Singleton;
using System.Collections.Concurrent;
using System.Threading;

namespace SamoLetoAPI.Data
{
    public class FlightResources : IFlightResources
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

        public BaseResponseDTO ReserveSeat(string flightNumber)
        {
            var errorCode = ErrorCode.OK;
            try
            {
                if (flightsemaphores.TryGetValue(flightNumber, out SemaphoreSlim? semaphore) && semaphore != null)
                {
                    semaphore.Wait();
                    int availableTickets;
                    if (flightTicketsDict.TryGetValue(flightNumber, out availableTickets) && availableTickets > 0)
                    {
                        flightTicketsDict[flightNumber]--;
                        semaphore.Wait(5000);
                    }
                    else
                    {
                        errorCode = ErrorCode.NoTicketsAvailable;
                    }
                    semaphore.Release();
                }
            }
            catch (Exception)
            {
                errorCode = ErrorCode.DefaultError;
            }
            finally
            {
                flightsemaphores.TryGetValue(flightNumber, out SemaphoreSlim? semaphore);
                semaphore?.Release();
            }
            return new(errorCode);

        }

        public async Task<BaseResponseDTO> Lock(string flightNumber, TimeSpan duration)
        {
            var errorCode = ErrorCode.OK;
            if (flightsemaphores.TryGetValue(flightNumber, out SemaphoreSlim? semaphore) && semaphore != null)
            {
                try
                {
                    semaphore.Wait();
                    await Task.Delay(duration);
                    semaphore.Release();
                }
                catch (Exception)
                {
                    errorCode = ErrorCode.DefaultError;
                }
                finally
                {
                    semaphore.Release();
                }
            }
            return new(errorCode);
        }
    }
}
