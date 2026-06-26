using DesignPatterns.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DesignPatterns.Infraestructure.DependencyInjection
{
    public class ServicesConfiguration
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // PATRÓN REPOSITORY + INYECCIÓN DE DEPENDENCIAS
            // El controlador depende de la abstracción IVehicleRepository, no de una
            // implementación concreta. Esto permite cambiar el origen de datos sin tocar
            // el resto del código (principio de Inversión de Dependencias - SOLID).

            // BUG REPORTADO POR QA:
            // Antes estaba registrado como AddTransient, que crea una NUEVA instancia del
            // repositorio en CADA inyección. Como MyVehiclesRepository guarda los vehículos
            // en una lista EN MEMORIA, cada request empezaba con una lista vacía y los
            // vehículos agregados "desaparecían". Con Singleton la lista en memoria se
            // mantiene viva durante toda la vida de la aplicación.
            services.AddSingleton<IVehicleRepository, MyVehiclesRepository>();

            // Cuando el esquema de base de datos esté listo, basta con cambiar la línea de
            // arriba por la de abajo (y volver a Scoped/Transient). El resto del código NO
            // cambia gracias al patrón Repository.
            // services.AddScoped<IVehicleRepository, DBVehicleRepository>();
        }
    }
}
