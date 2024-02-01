using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HomebreweryShoppingAssistaint.Data;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCulture = "pl-PL";
    options.SetDefaultCulture(supportedCulture);
}); // Sprawdzić czy to zadziała.

builder.Services.AddDbContext<HomebreweryShoppingAssistaintContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HomebreweryShoppingAssistaintContext") ?? throw new InvalidOperationException("Connection string 'HomebreweryShoppingAssistaintContext' not found.")));
// Add services to the container.

builder.Services.AddControllersWithViews().AddJsonOptions(options => { 
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
if(app.Environment.IsDevelopment())
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
