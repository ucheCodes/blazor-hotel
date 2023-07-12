using Hotel.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Org.BouncyCastle.Utilities.Collections;
using AppDatabase;
using AppMailService;
using AppStore;
using AppController;

var builder = WebApplication.CreateBuilder(args);
//var config_ = builder.Configuration["keys"];

/*Configuration for secrets*/
var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var configBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);  // Add your existing appsettings.json file

if (env == Environments.Production)
{
    configBuilder.AddJsonFile("appsettings.Production.json", optional: false, reloadOnChange: true);
}
else
{
    configBuilder.AddJsonFile("appsettings.Production.json", optional: false, reloadOnChange: true);
}
var configuration = configBuilder.Build();



// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.AddSingleton<GetSecrets>();
builder.Services.AddScoped<SignalRService>();
builder.Services.AddScoped<IDatabase, Database>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IStore, Store>();
builder.Services.AddScoped<IKitchenControl, KitchenControl>();
builder.Services.AddScoped<INotificationControl,NotificationControl>();
builder.Services.AddScoped<IUserControl, UserControl>();
builder.Services.AddScoped<IRoomControl,RoomControl>();
builder.Services.AddScoped<IBlogControl, BlogControl>();
builder.Services.AddScoped<IPaystackControl,PaystackControl>();
builder.Services.AddHttpClient();

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


//Addding signalr dependency
app.UseEndpoints(endpoints =>
{
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
    endpoints.MapHub<AppHub>(AppHub.HubUrl);
});
//app.MapGet("/", () => config_);
app.Run();
