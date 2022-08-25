using TodoAPI.Repositories;
using TodoAPI.Services;
using TodoAPI.Infrastructure.UoW;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Infrastructure;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();


builder.Services.AddDbContext<MovieDbContext>(c =>
{
    try
    {
        string connectionString = builder.Configuration.GetValue<string>("DefaultConnection");
        c.UseSqlServer(connectionString);
    }
    catch (Exception)
    {
        //var message = ex.Message;
    }
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<ISeanceRepository, SeanceRepository>();
builder.Services.AddScoped<ITicketsRepository, TicketsRepository>();

builder.Services.AddScoped<IFilmService, FilmService>();
builder.Services.AddScoped<ISeanceService, SeanceService>();
builder.Services.AddScoped<ITicketsService, TicketsService>();



var app = builder.Build();
app.MapControllers();

    app.Run();

