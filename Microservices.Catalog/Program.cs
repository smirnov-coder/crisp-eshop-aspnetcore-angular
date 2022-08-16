using Core.Swagger;
using Microservices.Catalog.Cqrs;
using Microservices.Catalog.DataAccess;
using Microservices.Catalog.Services;
using Newtonsoft.Json.Converters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddMongoDb()
    .AddCqrsHandlers()
    .AddTransient<IProductRepository, ProductRepository>()
    .AddTransient<IFileService, FileService>();

builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGenNewtonsoftSupport()
    .AddSwaggerGen(Assembly.GetExecutingAssembly().GetName().Name, "Catalog API");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    await DataInitializer.InitializeAsync(scope.ServiceProvider);
}

app.Run();