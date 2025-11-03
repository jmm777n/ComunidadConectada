using ComunidadConectada.Repositories;
using ComunidadConectada.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IParticipanteRepository, InMemoryParticipanteRepository>();
builder.Services.AddScoped<IParticipanteService, ParticipanteService>();

var app = builder.Build();

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
    pattern: "{controller=Participantes}/{action=Index}/{id?}");

app.Run();
