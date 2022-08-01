using Core.Swagger;
using Newtonsoft.Json.Converters;
using Refit;
using System.Reflection;
using Web.ClientUI.ApiClients;
using Web.ClientUI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IProductService, ProductService>();
//builder.Services.AddHttpClient<IProductService, ProductService>((services, client) =>
//{
//    var configuration = services.GetRequiredService<IConfiguration>();
//    client.BaseAddress = new Uri(configuration["Endpoints:Catalog"]);
//});

builder.Services
    .AddRefitClient<ICatalogApiClient>()
    .ConfigureHttpClient((services, client) =>
    {
        var configuration = services.GetRequiredService<IConfiguration>();
        client.BaseAddress = new Uri(configuration["Endpoints:Catalog"]);
    });

builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGenNewtonsoftSupport()
    .AddSwaggerGen(Assembly.GetExecutingAssembly().GetName().Name, "Crisp API");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("v1/swagger.json", "Crisp API v1"));
}

app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();

app.MapFallbackToFile("index.html"); ;

app.Run();
