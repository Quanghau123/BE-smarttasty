using ChatbotService.Application.Interfaces;
using ChatbotService.Application.Services;
using ChatbotService.Infrastructure.Messaging.Kafka;

var builder = WebApplication.CreateBuilder(args);

// ==========================
// HttpContext + CORS
// ==========================
builder.Services.AddHttpContextAccessor();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "https://smart-tasty.io.vn") // các FE cần truy cập
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // cần khi FE gửi cookie / withCredentials
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

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();
app.Run();
