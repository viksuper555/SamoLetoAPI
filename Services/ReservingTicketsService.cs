using SamoLetoAPI.Controllers;
using SamoLetoAPI.Data;
using SamoLetoAPI.DTO;
using SamoLetoAPI.Singleton;

namespace SamoLetoAPI.Services
{
    public class ReservingTicketsService : IReservingTicketsService
    {
        private readonly IFlightResources _flightResources;
        private ILogger<ReservingTicketsService> _logger;

        public ReservingTicketsService(ILogger<ReservingTicketsService> logger, IFlightResources sharedDictionary)
        {
            _logger = logger;
            _flightResources = sharedDictionary;
        }

        public async Task<BaseResponseDTO> Lock(string flightnumber, TimeSpan duration)
        {
            try
            {
                return await _flightResources.Lock(flightnumber, duration);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new(ErrorCode.DefaultError);
            }
        }

        public async Task<BaseResponseDTO> ReserveSeat(string flightnumber)
        {
            try
            {
                return _flightResources.ReserveSeat(flightnumber);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new(ErrorCode.DefaultError);
            }
        } 
    }
}
