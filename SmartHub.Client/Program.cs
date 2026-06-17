using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SmartHub.Client.Services;
using SmartHub.UI;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();

builder.Services.AddScoped(sp => new HttpClient()
{
    BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"] ?? "https://localhost:7131/api/")
});

builder.Services.AddScoped<IDeviceService, ClientDeviceService>();

await builder.Build().RunAsync();
