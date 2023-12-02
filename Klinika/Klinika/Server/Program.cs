global using Microsoft.EntityFrameworkCore;
using Klinika.Server.Data;
using Klinika.Server.Services.DoktorService;
using Klinika.Server.Services.OdeljenjeService;
using Klinika.Server.Services.PacijentService;
using Klinika.Server.Services.PregledService;
using Microsoft.AspNetCore.ResponseCompression;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IDoktorService, DoktorService>();
builder.Services.AddScoped<IOdeljenjeService, OdeljenjeService>();
builder.Services.AddScoped<IPacijentService, PacijentService>();
builder.Services.AddScoped<IPregledService, PregledService>();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
