
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Taller.Api.Filters;
using Taller.Api.Middlewares;
using Taller.Application.Cores.Context;
using Taller.Infraestructure.Cores.Context;
using Serilog;
using Serilog.Events;
using Microsoft.AspNetCore.Identity;
using Taller.Core.Securities.Services.Implementations;
using Taller.Core.Securities.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

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

    AuthorizationPolicy authorizationPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();

    options.Filters.Add(new AuthorizeFilter()); //Filtrando la validacin para los controller, para indicar que deben estar protegidos

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

//PasswordHasher

builder.Services.Configure<PasswordHasherOptions>(options =>
{
    options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3;
});


//JWT
string jwtSecretKey = builder.Configuration.GetSection("Secutiry:JwSecrectKey").Get<string>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    byte[] key = Encoding.ASCII.GetBytes(jwtSecretKey);
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateLifetime = true,
        ValidIssuer = "",
        ValidAudience = "",
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true
    };
});

//AuthorizeOperationFilter
builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<AuthorizeOperationFilter>(); //Para indicar cuales tienen seguridad y cuales no
    string schemeName = "Bearer";
    options.AddSecurityDefinition(schemeName, new OpenApiSecurityScheme() //Para poder ingresar el token de seguridad una vez generado
    {
        Name = schemeName,
        BearerFormat = "JWT",
        Scheme = "bearer",
        Description = "Add Token.",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http
    });

});


//IsecutiryService

builder.Services.AddTransient<ISecurityService, SecurityService>();


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
