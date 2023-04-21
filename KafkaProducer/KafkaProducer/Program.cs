using Confluent.Kafka;
using KafkaProducer.Data.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var producerConfig = new ProducerConfig();
builder.Configuration.Bind("producerconfiguration", producerConfig);
builder.Services.AddSingleton<ProducerConfig>(producerConfig);

builder.Services.AddSingleton<ProducerService>();

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
