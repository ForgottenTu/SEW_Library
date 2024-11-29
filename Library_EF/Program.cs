using System.Reflection;
using Domain.Interfaces;
using Library_DB;
using Library_EF.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;



var builder = WebApplication.CreateBuilder(args);
var conf = builder.Configuration;
var assembly = Assembly.GetExecutingAssembly();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Mud Service View
builder.Services.AddMudServices();

builder.Services.AddDbContext<LibraryContext>(options =>
{
    options.UseSqlite(conf.GetConnectionString("DefaultConnection"), sqliteOptions =>
    {
        sqliteOptions.MigrationsAssembly(assembly.FullName);
    });
});

//register Repositories
builder.Services.AddTransient<IRepository<Book>,ARepository<Book>>();
builder.Services.AddTransient<IRepository<Author>, ARepository<Author>>();
builder.Services.AddTransient<IRepository<BookDetails>, ARepository<BookDetails>>();


var app = builder.Build();


app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();