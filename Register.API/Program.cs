using Microsoft.EntityFrameworkCore;
using Register.API.Data;
using Register.API.Repositories;
using System.Diagnostics.Metrics;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConnectionMySql = builder.Configuration.GetConnectionString("ConnectionMySql");
builder.Services.AddDbContext<APIDbContext>(x => x.UseMySql(
    ConnectionMySql,
    ServerVersion.Parse("8.0.35")
)
);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();

//builder.Services.AddScoped(http => new HttpClient
//{
//    BaseAddress = new Uri(builder.Configuration.GetSection("BaseAddress").Value!)
//});

builder.Services.AddHttpClient();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
