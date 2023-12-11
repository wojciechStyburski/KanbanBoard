using KanbanBoard.Client;
using KanbanBoard.Client.HttpStorage.Items;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("KanbanBoardAppApi", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiConfiguration:BaseAddress"]);
    client.Timeout = TimeSpan.FromMinutes(5);
});

builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("KanbanBoardAppApi"));
builder.Services.AddScoped<IItemStorage, ItemStorage>();

await builder.Build().RunAsync();
