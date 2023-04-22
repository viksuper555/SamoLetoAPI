using SamoLetoAPI.Singleton;

namespace SamoLetoAPI.Services.Background
{
    public class TicketBuyerWorker : BackgroundService
    {
        private readonly ILogger<TicketBuyerWorker> _logger;
        private readonly IReservingTicketsService _reservingTicketsService;

        private static string flightNumber = "Flight 77";
        public TicketBuyerWorker(ILogger<TicketBuyerWorker> logger, IReservingTicketsService reservingTicketsService)
        {
            _logger = logger;
            _reservingTicketsService = reservingTicketsService;
        }

        protected async override Task ExecuteAsync(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                await Task.Delay(1000, ct);

                try
                {
                    await _reservingTicketsService.ReserveSeat(flightNumber);

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
        }
    }
}
