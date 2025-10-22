using ChatbotService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// HttpClient + DI services
builder.Services.AddHttpClient<N8nWebhookService>();
builder.Services.AddHttpClient<SmartTastyServiceClient>();

builder.Services.AddScoped<N8nWebhookService>();
builder.Services.AddScoped<SmartTastyServiceClient>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
