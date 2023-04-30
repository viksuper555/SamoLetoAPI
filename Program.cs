using Microsoft.Extensions.DependencyInjection;
using SamoLetoAPI.Data;
using SamoLetoAPI.Services;
using SamoLetoAPI.Services.Background;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IFlightResources, FlightResources>();
builder.Services.AddSingleton<IReservingTicketsService, ReservingTicketsService>();

builder.Services.AddHostedService(
            container => new TicketBuyerWorker(
                container.GetRequiredService<ILogger<TicketBuyerWorker>>(),
                container.GetRequiredService<IReservingTicketsService>()
            ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
