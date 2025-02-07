using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OrderManagement.API.Extensions;
using OrderManagement.API.Hubs;
using OrderManagement.Business.Validators.AboutValidators;
using OrderManagement.Business.Validators.BookingValidators;
using OrderManagement.DataAccess.Context;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddServiceExtensions();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });
});

builder.Services.AddSignalR();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddValidatorsFromAssemblyContaining<CreateAboutValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateAboutValidator>();

builder.Services.AddValidatorsFromAssemblyContaining<CreateBookingValidator>();

ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr");

builder.Services.AddDbContext<OrderManagementContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();

builder.Services.AddControllersWithViews().AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Restaurant API");
    });
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/signalrhub");

app.Run();
