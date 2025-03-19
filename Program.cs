using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoVagas.Data;
using ProjetoVagas.Repositorio;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Adiciona serviços ao contêiner
        builder.Services.AddControllersWithViews();

        builder.Services.AddEntityFrameworkSqlServer()
            .AddDbContext<VagaDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
            );

        builder.Services.AddHttpClient<AdzunaService>()
            .ConfigureHttpClient(client =>
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            });

        builder.Services.AddScoped<IAdzunaService, AdzunaService>(); // Manter como scoped
        builder.Services.AddHostedService<AdzunaHostedService>(); // Adicionar como serviço hospedado

        var app = builder.Build();

        // Configurar o pipeline de requisições HTTP
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
    }
}




