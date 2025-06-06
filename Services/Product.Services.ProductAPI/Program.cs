using Consul;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Ocelot.Values;
using Product.Services.ProductAPI;
using Product.Services.ProductAPI.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//builder.Services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(cfg =>
//{
//    cfg.Address = new Uri("http://consul:8500");
//}));

//builder.Services.AddHostedService<ConsulServiceRegistration>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product API", Version = "v1" });
    var isDocker = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";
    if (isDocker)
        c.AddServer(new OpenApiServer { Url = "/productapi" });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment() || true)
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var isDocker = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";
        if (isDocker)
            options.SwaggerEndpoint("/productapi/swagger/v1/swagger.json", "Product API V1");
        else
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API V1");
    });
}
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
public partial class Program { }
