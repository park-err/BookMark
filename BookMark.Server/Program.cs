using BookMark.Server.Services;
using BookMark.Server.Config;
using BookMark.Server.Handlers;
using Microsoft.Extensions.Options;
using BookMark.Server.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// GoogleBooksApi config
builder.Services.Configure<GoogleBooksOptions>(builder.Configuration.GetSection("GoogleBooksApi"));

// retry handler
builder.Services.AddTransient<RetryHandler>();

// Google Books API service register
builder.Services.AddHttpClient<ICatalogService, CatalogService>((provider, client) =>
{
    var options = provider.GetRequiredService<IOptions<GoogleBooksOptions>>().Value;
    var baseUrl = options.BaseAddress ?? builder.Configuration["GoogleBooksApi:BaseUrl"]!;
    client.BaseAddress = new Uri(baseUrl);
    client.Timeout = System.TimeSpan.FromSeconds(10);
    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
})
    .AddHttpMessageHandler<RetryHandler>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Swagger Setup
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Version = "v1",
        Title = "BookMark API",
        Description = "An ASP.NET Core Web API for managing BookMark book lists.",
        // TermsOfService = new Uri("https://example.com/terms"),
    });
});

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Global exception handling middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
