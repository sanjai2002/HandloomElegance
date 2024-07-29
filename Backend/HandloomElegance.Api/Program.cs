using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Core.IServices;
using HandloomElegance.Core.Services;
using HandloomElegance.Data.IRepository;
using HandloomElegance.Data.Repository;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserServices,userServices>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<HandloomEleganceDbContext>();
// Add services to the container.

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
