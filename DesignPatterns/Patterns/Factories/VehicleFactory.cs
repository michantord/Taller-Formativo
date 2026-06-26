using DesignPatterns.Models;
using DesignPatterns.Patterns.Builders;

namespace DesignPatterns.Patterns.Factories
{
    /// <summary>
    /// PATRÓN FACTORY METHOD (Método de Fábrica).
    ///
    /// Define el "molde" para crear vehículos, pero delega en cada subclase la decisión de
    /// QUÉ vehículo concreto se crea (CreateVehicle). El Arquitecto de Software prevé que
    /// el negocio agregará más modelos; con este patrón, agregar un modelo nuevo = crear una
    /// nueva fábrica concreta, SIN modificar el código existente (Abierto/Cerrado - SOLID).
    /// </summary>
    public abstract class VehicleFactory
    {
        /// <summary>
        /// Factory Method: cada fábrica concreta decide qué modelo de vehículo instanciar.
        /// </summary>
        protected abstract Vehicle CreateVehicle();

        /// <summary>
        /// Operación de fábrica de alto nivel: crea el vehículo y le aplica las
        /// propiedades por defecto usando el patrón Builder (año actual + propiedades del
        /// negocio). Así combinamos Factory Method (qué modelo) + Builder (cómo se configura).
        /// </summary>
        public Vehicle Build()
        {
            var vehicle = CreateVehicle();

            return new VehicleBuilder(vehicle)
                .WithCurrentYear()
                .WithDefaultProperties()
                .Build();
        }
    }
}
