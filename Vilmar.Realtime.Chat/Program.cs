using MassTransit;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using System.Reflection;
using Vilmar.Realtime.Chat.Areas.Bot;
using Vilmar.Realtime.Chat.Areas.Chat;
using Vilmar.Realtime.Chat.Areas.Identity;
using Vilmar.Realtime.Chat.Areas.Message;
using Vilmar.Realtime.Chat.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddScoped<IMessageRepository,MessageRepository>();
builder.Services.AddScoped<BotService>();

builder.Services.AddMassTransit(busConfigurator =>
{
    var entryAssembly = Assembly.GetExecutingAssembly();
    busConfigurator.AddConsumers(entryAssembly);
    busConfigurator.UsingRabbitMq((context, busFactoryConfigurator) =>
    {
        busFactoryConfigurator.Host("localhost", "/", h => {
            h.Username("guest");
            h.Password("guest");
        });
        busFactoryConfigurator.ConfigureEndpoints(context);
    });
});

builder.Services.AddHttpClient("stooq", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://stooq.com/q/l");
     
    httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
});

var app = builder.Build();
app.MapHub<ChatHub>("/chat");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
