using SamoLetoAPI.DTO;

namespace SamoLetoAPI.Services
{
    public interface IReservingTicketsService
    {
        public Task<BaseResponseDTO> ReserveSeat(string flightnumber);
    }
}
