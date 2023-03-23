using Microsoft.Extensions.Hosting;

using TrafficLight_Api.Services;
using TrafficLight_Api.Services.Abstractions;
using TrafficLight_Api.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ITrafficLightService, TrafficLightService>();
builder.Services.AddTransient<ITimerEvent, TimerEvent>();
builder.Services.AddHostedService<TrafficLightApiHostedService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
