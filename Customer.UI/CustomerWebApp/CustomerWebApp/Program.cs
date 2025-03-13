using MudBlazor.Services;
using CustomerWebApp.Components;
using DotNetEnv;
using CustomerWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

// Access the environment variables
string apiBaseUrl = Environment.GetEnvironmentVariable("MICRO_SERVICE_URL");

ApiService.ApiBaseUrl = apiBaseUrl;

// Add MudBlazor services
builder.Services.AddHttpClient();
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
