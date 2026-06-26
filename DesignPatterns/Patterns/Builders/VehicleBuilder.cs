using System;
using DesignPatterns.Models;

namespace DesignPatterns.Patterns.Builders
{
    /// <summary>
    /// PATRÓN BUILDER (Constructor).
    ///
    /// Permite construir/configurar un <see cref="Vehicle"/> paso a paso mediante una
    /// interfaz fluida, separando la lógica de "cómo se arman los valores por defecto"
    /// del objeto en sí.
    ///
    /// ¿Por qué Builder y no agregar parámetros al constructor?
    /// El equipo de negocio pidió el "año actual" y "20 propiedades por defecto" que
    /// llegarán el próximo sprint. Si pusiéramos todo eso en el constructor, este crecería
    /// sin control (anti-patrón "telescoping constructor") y cada nueva propiedad obligaría
    /// a cambiar TODAS las llamadas existentes.
    ///
    /// Con el Builder, agregar una propiedad por defecto el próximo sprint = una línea más
    /// en <see cref="WithDefaultProperties"/>. El resto del código no se entera. Esto
    /// minimiza los cambios para el siguiente sprint (Principio Abierto/Cerrado - SOLID).
    /// </summary>
    public class VehicleBuilder
    {
        private readonly Vehicle _vehicle;

        public VehicleBuilder(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }

        /// <summary>Asigna el año actual del sistema al vehículo.</summary>
        public VehicleBuilder WithCurrentYear()
        {
            _vehicle.Year = DateTime.Now.Year;
            return this;
        }

        /// <summary>Permite asignar (o sobrescribir) una propiedad puntual.</summary>
        public VehicleBuilder WithProperty(string key, object value)
        {
            _vehicle.Properties[key] = value;
            return this;
        }

        /// <summary>
        /// Carga las propiedades por defecto solicitadas por el negocio.
        ///
        /// PRÓXIMO SPRINT: cuando lleguen las 20 propiedades definitivas, solo se agregan
        /// aquí como nuevas líneas WithProperty(...). No hay que tocar Vehicle, ni el
        /// controlador, ni el repositorio.
        /// </summary>
        public VehicleBuilder WithDefaultProperties()
        {
            // Ejemplos de "propiedades por defecto" (placeholders para el próximo sprint):
            WithProperty("Transmission", "Automatic");
            WithProperty("Doors", 4);
            WithProperty("Warranty", "3 years");
            // ... aquí se irán sumando las demás propiedades por defecto.
            return this;
        }

        /// <summary>Devuelve el vehículo ya configurado.</summary>
        public Vehicle Build()
        {
            return _vehicle;
        }
    }
}
