using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Kyrldama.Backoffice.DataAccess;
using Kyrldama.Backoffice.Host;
using Kyrldama.Backoffice.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddAuthorization();
builder.Services.AddControllers();    

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";
    if (app.Environment.IsDevelopment())
    {
        // Launch development server for Vue.js
        spa.UseProxyToSpaDevelopmentServer("http://localhost:8081");
    }
});

app.Run();
