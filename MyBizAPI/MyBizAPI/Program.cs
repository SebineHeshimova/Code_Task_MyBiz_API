using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using MyBizAPI.DATA;
using MyBizAPI.DTOs.PositionDTOs;
using MyBizAPI.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(option =>
{
    option.RegisterValidatorsFromAssembly(typeof(CreatePositionDTOValidator).Assembly);
});
builder.Services.AddAutoMapper(typeof(MapProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyBizDbContext>(options => { options.UseSqlServer("Server=DESKTOP-RME1C3K;Database=MyBizAPI;Trusted_Connection=True;"); });
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
