using HomebreweryShoppingAssistaint.Converters;
using HomebreweryShoppingAssistaint.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.Json.Serialization;

var globalApplicationCulture = CultureInfo.GetCultureInfo("pl-PL");
CultureInfo.DefaultThreadCurrentCulture = globalApplicationCulture;
CultureInfo.DefaultThreadCurrentUICulture = globalApplicationCulture;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HomebreweryShoppingAssistaintContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HomebreweryShoppingAssistaintContext") ?? throw new InvalidOperationException("Connection string 'HomebreweryShoppingAssistaintContext' not found.")));
// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.Converters.Add(new CustomDateTimeConverter());
    options.JsonSerializerOptions.Converters.Add(new CustomDateOnlyConverter());
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
