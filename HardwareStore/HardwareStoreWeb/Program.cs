using HardwareStoreWeb;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options => options.LoginPath = "/Login");
builder.Services.AddAuthorization();

builder.Services.AddRazorPages();

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(optionsBuilder =>
{
    optionsBuilder.UseNpgsql($"Host={DbData.Host};Port={DbData.Port};Database={DbData.Database};Username={DbData.Username};Password={DbData.Password}");
    optionsBuilder.UseLazyLoadingProxies();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
	var supportedCultures = new[] { new CultureInfo("ru") };
	options.DefaultRequestCulture = new RequestCulture(culture: "ru", uiCulture: "ru");
	options.SupportedCultures = supportedCultures;
	options.SupportedUICultures = supportedCultures;
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
	options.JsonSerializerOptions.WriteIndented = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
else
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//app.MapGet("/todoitems", async (TodoDb db) =>
//    await db.Todos.ToListAsync());

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

app.MapDefaultControllerRoute();

app.Run();
