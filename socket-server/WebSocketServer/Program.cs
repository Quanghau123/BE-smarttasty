using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.SignalR;
using System.Text;
using WebSocketServer.Application.Hubs;
using WebSocketServer.Application.Services;
using WebSocketServer.Infrastructure.Messaging.Kafka;

var builder = WebApplication.CreateBuilder(args);
Console.WriteLine("Builder created");

// ===== Register HttpClientFactory =====
// resolve IHttpClientFactory trong NotificationHub
builder.Services.AddHttpClient("NotificationService", client =>
{
    client.BaseAddress = new Uri("http://localhost:5088/");
});

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

// ===== SignalR =====
builder.Services.AddSignalR();

// ===== SocketNotificationService =====
// FIX: đăng ký Singleton để hub + KafkaDispatcher dùng chung
builder.Services.AddSingleton<SocketNotificationService>();

// ===== KafkaDispatcher =====
// FIX: vẫn giữ Scoped, resolve bằng scope trong KafkaConsumerService
builder.Services.AddScoped<KafkaDispatcher>();

// ===== KafkaConsumerService =====
builder.Services.AddHostedService<KafkaConsumerService>();

// ===== JWT Authentication =====
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        Console.WriteLine("Configuring JwtBearer");
        var cfg = builder.Configuration;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(cfg["Jwt:SecretKey"]!))
        };

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = ctx =>
            {
                var accessToken = ctx.Request.Query["access_token"];
                var path = ctx.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hubs/notification"))
                {
                    ctx.Token = accessToken;
                }
                return Task.CompletedTask;
            }
        };
    });

var app = builder.Build();
Console.WriteLine("App built");

// ===== Middleware =====
app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

Console.WriteLine("Middleware configured");

// ===== Map SignalR Hub =====
app.MapHub<NotificationHub>("/hubs/notification");
Console.WriteLine("Hubs mapped");

// ===== Run =====
Console.WriteLine("Running app");
app.Run();
