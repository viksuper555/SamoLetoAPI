using Microsoft.AspNetCore.Mvc;
using SamoLetoAPI.DTO;
using SamoLetoAPI.Services;
using SamoLetoAPI.Singleton;

namespace SamoLetoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly IReservingTicketsService _reservingTicketsService;

        public TicketController(IReservingTicketsService reservingTicketsService) 
        { 
            _reservingTicketsService = reservingTicketsService;
        }

        [HttpPost("Buy")]
        public async Task<BaseResponseDTO> BuyTicket(string flightNumber)
        {
            return await _reservingTicketsService.ReserveSeat(flightNumber);
        }
    }
}
