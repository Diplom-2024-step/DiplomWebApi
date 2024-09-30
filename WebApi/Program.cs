using AnytourApi.WebApi.Extensions;
using AnytourApi.Application.Services.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using System.ComponentModel;
using Microsoft.Extensions.Hosting;
using WebApiForHikka.WebApi.Conventions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers()
    .AddMvcOptions(o => o.Conventions.Add(new RelationControllerModelConvention()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT token into field",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        [new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            },
            Scheme = "oauth2",
            Name = "Bearer",
            In = ParameterLocation.Header
        }] = []
    });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddApplication(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddLoggingMiddleware();
builder.Services.Configure<TokenOptions>(builder.Configuration.GetSection("TokenOptions"));

builder.Services.AddIdentity();
builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddPolicies();
var app = builder.Build();
app.UseCors(builder => builder.WithOrigins("*")
                              .AllowAnyHeader()
                              .AllowAnyMethod());
app.UseOptions();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication(); // Use authentication middleware
app.UseAuthorization(); // Use authorization middleware

app.UseLoggingMiddleware();
app.MapControllers();

app.Run();

//!!!!!!!!!!!!!! DON'T DELETE IT, IT'S NEEDED FOR INTEGRATION TESTS !!!!!!!!!!!!!!!!!!!!!!!!!!!!
public partial class Program { }
