using System.Reflection;
using Library_DB;
using Library_EF.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var conf = builder.Configuration;
var assembly = Assembly.GetExecutingAssembly();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<LibraryContext>(options =>
{
    options.UseSqlite(conf.GetConnectionString("DefaultConnection"), sqliteOptions =>
    {
        sqliteOptions.MigrationsAssembly(assembly.FullName);
    });
});
builder.Services.AddTransient<ARepository<Book>>();

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