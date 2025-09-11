using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using NotificationService.Application.Services;
using NotificationService.Application.Interfaces.Services;
using NotificationService.Infrastructure.Messaging.Fcm;
using NotificationService.Infrastructure.Messaging.Kafka;
using NotificationService.Infrastructure.Cache;
using NotificationService.Infrastructure.Persistence.Repositories;
using NotificationService.Application.Interfaces.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình MongoDB
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("MongoDb");
    return new MongoClient(connectionString);
});

builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var configuration = sp.GetRequiredService<IConfiguration>();
    var databaseName = configuration["MongoDbSettings:DatabaseName"];
    return client.GetDatabase(databaseName);
});

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

// Add controllers
builder.Services.AddControllers();

// ===== Kafka Services =====
builder.Services.AddSingleton<KafkaProducerService>();
builder.Services.AddScoped<KafkaDispatcher>();
builder.Services.AddHostedService<KafkaConsumerService>();

// ===== Other Services =====

/*delete*/

// builder.Services.AddSingleton<PushService>(sp =>
// {
//     var fcmService = sp.GetRequiredService<IFcmNotificationService>();
//     var logger = sp.GetRequiredService<ILogger<PushService>>();
//     var config = sp.GetRequiredService<IConfiguration>();
//     var kafkaProducer = sp.GetRequiredService<KafkaProducerService>();
//     return new PushService(fcmService, logger, config, kafkaProducer);
// });
builder.Services.AddSingleton<EmailService>();
builder.Services.AddSingleton<SocketClusterService>();
builder.Services.AddHttpClient<IFcmNotificationService, FcmNotificationService>();
builder.Services.AddSingleton<IUserStatusService, RedisUserStatusService>();
builder.Services.AddScoped<INotificationHandler, NotificationHandler>();
builder.Services.AddScoped<IOfflineNotificationRepository, OfflineNotificationRepository>();
builder.Services.AddScoped<IOfflineNotificationService, OfflineNotificationService>();

// Redis
builder.Services.AddSingleton<RedisCacheService>();

var app = builder.Build();

app.UseCors("AllowAll");
app.MapControllers();

app.Run();
