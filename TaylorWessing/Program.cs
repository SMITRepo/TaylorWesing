using ClientMatterSolution.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using TaylorWessing.Contracts;
using TaylorWessing.Persistence;
using Microsoft.EntityFrameworkCore;
using TaylorWessing.Persistence.Repos;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TaylorWessingDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TaylorWessingConnectionString")));

builder.Services.AddScoped<TaylorWessingRepo>();
builder.Services.AddHttpClient<IApiService, ApiService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:ApiUrl"]);
    client.DefaultRequestHeaders.Add(builder.Configuration["ApiSettings:ApiKeyName"], builder.Configuration["ApiSettings:ApiKeyValue"]);

});



// Add controllers with views (for MVC)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Client}/{action=Index}/{id?}");

app.Run();