using SamoLetoAPI.DTO;
using System.Collections.Concurrent;

namespace SamoLetoAPI.Data
{
    public interface IFlightResources
    {
        public BaseResponseDTO ReserveSeat(string flightNumber);
        public Task<BaseResponseDTO> Lock(string flightNumber, TimeSpan duration);
    }
}
