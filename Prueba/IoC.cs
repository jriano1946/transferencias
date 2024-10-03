namespace Prueba
{
    using Data;
    using Domain.Implementation;
    using Domain.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Repository;
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ContextDb>(db => db.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork>(sp => new UnitOfWork(
                sp.GetRequiredService<DbContextOptions<ContextDb>>(),
                sp.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection")));
            services.AddScoped<IMovimientos, MovimientosBusiness>();
            services.AddScoped<ICuentas, CuentasBusiness>();
            services.AddScoped<IUsuarios, UsuariosBusiness>();
            return services;
        }
    }
}
