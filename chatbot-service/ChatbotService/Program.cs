using ChatbotService.Application.Interfaces;
using ChatbotService.Application.Services;
using ChatbotService.Infrastructure.Messaging.Kafka;

var builder = WebApplication.CreateBuilder(args);

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// ===== Kafka Services =====
builder.Services.AddSingleton<KafkaProducerService>();
builder.Services.AddScoped<KafkaDispatcher>();
builder.Services.AddHostedService<KafkaConsumerService>();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "ChatbotService_";
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// HttpClient + DI services
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IUserStatusService, UserStatusService>();

builder.Services.AddHttpClient<N8nWebhookService>();

builder.Services.AddScoped<N8nWebhookService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();
