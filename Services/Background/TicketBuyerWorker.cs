using SamoLetoAPI.Singleton;

namespace SamoLetoAPI.Services.Background
{
    public class TicketBuyerWorker : BackgroundService
    {
        private readonly ILogger<TicketBuyerWorker> _logger;
        private readonly ISharedDictionary _sharedDictionary;


        public TicketBuyerWorker(ILogger<TicketBuyerWorker> logger, ISharedDictionary sharedDictionary)
        {
            _logger = logger;
            _sharedDictionary = sharedDictionary;
        }

        protected async override Task ExecuteAsync(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                await Task.Delay(1000, ct);

                try
                {
                    var value = _sharedDictionary.AvailableTickets.ContainsKey("");

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
        }
    }
}
