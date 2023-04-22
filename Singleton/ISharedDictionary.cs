using SamoLetoAPI.DTO;
using System.Collections.Concurrent;

namespace SamoLetoAPI.Singleton
{
    public interface ISharedDictionary
    {
        public Task<BaseResponseDTO> ReserveSeat(string flightNumber);
    }
}
