using System.Globalization;
using System.Text.Json.Serialization;
using HomebreweryShoppingAssistant.Converters;
using HomebreweryShoppingAssistant.Data;
using HomebreweryShoppingAssistant.Services;
using Microsoft.EntityFrameworkCore;

var globalApplicationCulture = CultureInfo.GetCultureInfo("pl-PL");
CultureInfo.DefaultThreadCurrentCulture = globalApplicationCulture;
CultureInfo.DefaultThreadCurrentUICulture = globalApplicationCulture;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext") ?? throw new InvalidOperationException("Connection string 'AppDbContext' not found."));
});

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
	options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
	options.JsonSerializerOptions.Converters.Add(new CustomDateTimeConverter());
	options.JsonSerializerOptions.Converters.Add(new CustomDateOnlyConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IFermenterService, FermenterService>();
builder.Services.AddScoped<IGeneralProductService, GeneralProductService>();
builder.Services.AddScoped<IProductCheckHistoryService, ProductCheckHistoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IShopCheckHistoryService, ShopCheckHistoryService>();
builder.Services.AddScoped<IShopService, ShopService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseHsts();
	app.UseExceptionHandler();
}
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();


app.MapControllers();

app.Run();
