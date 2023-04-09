using Microsoft.AspNetCore.Mvc;
using SamoLetoAPI.DTO;
using SamoLetoAPI.Singleton;

namespace SamoLetoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
    
        private readonly ILogger<TicketController> _logger;
        private readonly ISharedDictionary _sharedDictionary;

        public TicketController(ILogger<TicketController> logger, ISharedDictionary sharedDictionary) 
        { 
            _logger = logger;
            _sharedDictionary = sharedDictionary;
        }

        [HttpPost("Buy")]
        public async Task<BaseResponseDTO> BuyTicket()
        {
            _sharedDictionary.AvailableTickets.TryAdd("","aaa");

            return new(ErrorCode.OK);
        }
    }
}
