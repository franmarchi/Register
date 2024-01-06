using Register.API.Repositories;
using Register.WEB.Components;
using Register.WEB.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<IPeopleRepository, PeopleService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7153/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddScoped<IPeopleRepository, PeopleService>();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7153/"),
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
