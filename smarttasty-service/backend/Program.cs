using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

using DotNetEnv;

using backend.Infrastructure.Configurations;
using backend.Infrastructure.Data;
using backend.Application.Interfaces;
using backend.Application.Interfaces.Commons;
using backend.Application.Services;
using backend.Application.Services.Commons;
using backend.Infrastructure.Helpers;
using backend.Infrastructure.Extensions;
using backend.Infrastructure.Messaging.Kafka;
using backend.Application.Jobs;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using Hangfire;
using Hangfire.PostgreSql;

var builder = WebApplication.CreateBuilder(args);

// ==========================
// JSON Settings
// ==========================
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
    });

// ==========================
// Swagger
// ==========================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ==========================
// HttpContext + CORS
// ==========================
builder.Services.AddHttpContextAccessor();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });

    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// ==========================
// Configuration Bindings
// ==========================
builder.Services.Configure<CloudinarySettings>(
    builder.Configuration.GetSection("CloudinarySettings"));

builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JwtSettings"));

// ==========================
// Database
// ==========================
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// ==========================
// AutoMapper
// ==========================
builder.Services.AddAutoMapper(typeof(Program));

// ==========================
// Custom Helpers (ImageHelper via DI)
// ==========================
builder.Services.AddSingleton(resolver =>
{
    var settings = resolver.GetRequiredService<IOptions<CloudinarySettings>>().Value;
    return new ImageHelper(settings);
});
builder.Services.AddSingleton<IImageHelper>(sp => sp.GetRequiredService<ImageHelper>());

// ===== Kafka Services =====
builder.Services.AddSingleton<KafkaProducerService>();
builder.Services.AddSingleton<KafkaDispatcher>();
builder.Services.AddHostedService<KafkaConsumerService>();

// ==========================
// Dependency Injection - Application Services
// ==========================
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IUserContextService, UserContextService>();
builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.AddScoped<IDishService, DishService>();
builder.Services.AddScoped<IPromotionService, PromotionService>();
builder.Services.AddScoped<IDishPromotionService, DishPromotionService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IRecipeReviewService, RecipeReviewService>();
builder.Services.AddScoped<IPaginationService, PaginationService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IApplyPromotionService, ApplyPromotionService>();
builder.Services.AddScoped<IOrderPromotionService, OrderPromotionService>();
builder.Services.AddScoped<IVoucherService, VoucherService>();
builder.Services.AddScoped<IVNPayService, VNPayService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IRefundService, RefundService>();
builder.Services.AddScoped<ICODService, CODService>();
builder.Services.AddScoped<PaymentJob>();

// Optional: Custom app services extension (nếu có)
builder.Services.AddAppServices(builder.Configuration);

// ==========================
// JWT Authentication
// ==========================
var secretKey = builder.Configuration["JwtSettings:SecretKey"];
var key = Encoding.UTF8.GetBytes(secretKey!);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

// ==========================
// Swagger
// ==========================

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' followed by your token"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

// ==========================
// Hangfire
// ==========================
builder.Services.AddHangfire(config =>
    config.UsePostgreSqlStorage(options =>
    {
        options.UseNpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"));
        // Bạn có thể config thêm các tùy chọn khác tại đây nếu cần
    })
);

builder.Services.AddHangfireServer();

var app = builder.Build();

// ==========================
// Build and Middleware
// ==========================
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Hangfire Dashboard
app.UseHangfireDashboard();

// Đăng ký job định kỳ SAU khi app và hangfire server đã khởi tạo
RecurringJob.AddOrUpdate<PaymentJob>(
    "check-pending-payments",
    job => job.CheckPendingPayments(),
    "*/5 * * * *"
);

app.Run();