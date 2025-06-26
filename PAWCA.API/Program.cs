using PAWCA.Architecture;
using PAWCA.Data.Repository;
using PAWCA.Data.Repository.Interfaces;
using PAWCA.Manager.Managers;
using PAWCA.Manager.Managers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<INewsManager, NewsManager>();
builder.Services.AddScoped<IRepositoryNews, RepositoryNews>();

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
