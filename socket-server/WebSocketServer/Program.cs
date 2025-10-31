using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.SignalR;
using System.Text;
using WebSocketServer.Application.Hubs;
using WebSocketServer.Application.Services;
using WebSocketServer.Infrastructure.Messaging.Kafka;

var builder = WebApplication.CreateBuilder(args);
Console.WriteLine("1️⃣ Builder created");

// ===== 0️⃣ Register HttpClientFactory =====
// 🔑 để resolve IHttpClientFactory trong NotificationHub
builder.Services.AddHttpClient("NotificationService", client =>
{
    client.BaseAddress = new Uri("http://localhost:5088/");
});

// ===== 1️⃣ CORS =====
var allowedOrigin = "http://localhost:3000";
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins(allowedOrigin)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // bắt buộc với JWT + SignalR
    });
});

// ===== 2️⃣ SignalR =====
builder.Services.AddSignalR();

// ===== 3️⃣ SocketNotificationService =====
// ✅ FIX: đăng ký Singleton để hub + KafkaDispatcher dùng chung
builder.Services.AddSingleton<SocketNotificationService>();

// ===== 4️⃣ KafkaDispatcher =====
// ✅ FIX: vẫn giữ Scoped, resolve bằng scope trong KafkaConsumerService
builder.Services.AddScoped<KafkaDispatcher>();

// ===== 5️⃣ KafkaConsumerService =====
builder.Services.AddHostedService<KafkaConsumerService>();

// ===== 6️⃣ JWT Authentication =====
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
Console.WriteLine("2️⃣ App built");

// ===== 7️⃣ Middleware =====
app.UseCors("CorsPolicy");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

Console.WriteLine("3️⃣ Middleware configured");

// ===== 8️⃣ Map SignalR Hub =====
app.MapHub<NotificationHub>("/hubs/notification");
Console.WriteLine("4️⃣ Hubs mapped");

// ===== 9️⃣ Run =====
Console.WriteLine("5️⃣ Running app");
app.Run();
