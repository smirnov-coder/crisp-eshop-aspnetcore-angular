using Core.Swagger;
using Microservices.Catalog.DataAccess;
using Newtonsoft.Json.Converters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IProductRepository, ProductRepository>();
Assembly.GetExecutingAssembly()
    .DefinedTypes
    .ToList()
    .ForEach(type =>
    {
        if (type.BaseType?.Name.Contains("HandlerBase") == true)
            builder.Services.AddTransient(type);
    });

//builder.Services.AddAutoMapper(typeof(MappingsProfile).Assembly);

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

app.Run();