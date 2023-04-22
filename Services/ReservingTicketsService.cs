using SamoLetoAPI.Controllers;
using SamoLetoAPI.DTO;
using SamoLetoAPI.Singleton;

namespace SamoLetoAPI.Services
{
    public class ReservingTicketsService : IReservingTicketsService
    {
        private readonly ISharedDictionary _sharedDictionary;
        private ILogger<ReservingTicketsService> _logger;

        public ReservingTicketsService(ILogger<ReservingTicketsService> logger, ISharedDictionary sharedDictionary)
        {
            _logger = logger;
            _sharedDictionary = sharedDictionary;
        }

        public async Task<BaseResponseDTO> ReserveSeat(string flightnumber)
        {
            try
            {
                return await _sharedDictionary.ReserveSeat(flightnumber);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new(ErrorCode.DefaultError);
            }
        } 
    }
}
