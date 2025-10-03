using HistoryOfScienceAPI.DataBase;
using HistoryOfScienceAPI.DataBase.Repositorys;
using HistoryOfScienceAPI.Interfaces.Repositorys;
using HistoryOfScienceAPI.Interfaces.Services;
using HistoryOfScienceAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddTransient<IPersonService, PersonService>();
builder.Services.AddTransient<IPersonRepository, PersonRepository>();

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();
