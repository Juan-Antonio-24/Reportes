using Gestion_Reportes.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Inyección de la cadena de conexión a la clase de contexto
var CadCon = builder.Configuration.GetConnectionString("cnReportesPBI");
builder.Services.AddDbContext<Gestion_Reportes_DBModel>
    (
        opciones => opciones.UseNpgsql(CadCon) // <-- Cambiado a UseNpgsql
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
