using EvalCedric.Components;
using EvalCedric.Data;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? "Data Source=evalcedric.db";

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Migration au démarrage de l'application
//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//    dbContext.Database.Migrate();
//}

app.Run();
