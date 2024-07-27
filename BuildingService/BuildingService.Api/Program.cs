using BuildingService.Application.Mapping;
using BuildingService.Application.Services;
using BuildingService.Db;
using BuildingService.Integrations;
using BuildingService.Integrations.Messages;
using BuildingService.Repository;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BuildingContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMassTransit(x =>
{
    x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
    {
        var rabbitMQConfig = builder.Configuration.GetSection("RabbitMQ");
        cfg.Host(rabbitMQConfig["Host"], "/", h =>
        {
            h.Username(rabbitMQConfig["Username"]);
            h.Password(rabbitMQConfig["Password"]);
        });

        // Настройка обменника
        cfg.Message<BuildingEventMessage>(x => x.SetEntityName("building-event-message"));
        cfg.Publish<BuildingEventMessage>(x => x.ExchangeType = ExchangeType.Topic);        
    }));
});

builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();
builder.Services.AddScoped<IBuildingService, BuildingService.Application.Services.BuildingService>();
builder.Services.AddScoped<IMessageSender, MessageSender>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

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
