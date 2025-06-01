using BackgroundServices.Api.BackgroundServices;
using BackgroundServices.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddScoped<IBankOperationsService, BankOperationsService>();

builder.Services.AddHostedService<AutomaticSettlementBackgroudService>();
builder.Services.AddHostedService<GenerateBankSlipBackgroundService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.Run();

