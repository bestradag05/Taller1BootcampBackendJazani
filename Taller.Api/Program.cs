
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Taller.Api.Filters;
using Taller.Api.Middlewares;
using Taller.Application.Cores.Context;
using Taller.Infraestructure.Cores.Context;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .WriteTo.Console(LogEventLevel.Information)
    .WriteTo.File(
    ".." + Path.DirectorySeparatorChar + "logapi.log",
    LogEventLevel.Warning
    )
    .CreateLogger();

builder.Logging.AddSerilog(logger);

// Add services to the container.


builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ValidationFilter());
});


//Route Options

builder.Services.Configure<RouteOptions>(options => //Configuramos las rutas mostradas
{
    options.LowercaseUrls = true; //Ponemos las rutas en minuscula
    options.LowercaseQueryStrings = true; //Configuramos los querys

});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Infraestructure

builder.Services.addInfraestructureServices(builder.Configuration);


//Aplications 

builder.Services.AddApplicationServices();

//Autofac

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(options =>
    {
        options.RegisterModule(new InfraestructureAutofacModule());
        options.RegisterModule(new AplicationAutofacModule());

    });


//API

builder.Services.AddTransient<ExceptionMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
