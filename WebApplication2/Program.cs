using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApplication2.DbContexts;
using WebApplication2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});
builder.Services.AddScoped<IUserRepository, UserRepository>();
UserOrderDbHelper.InitRepository();
builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("UserOrderDb"));

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

app.MapControllerRoute(
                name: "default",
                pattern: "{controller=AddList}/{action=Index}/{id?}");
app.Run();
