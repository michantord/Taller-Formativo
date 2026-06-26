using DesignPatterns.Models;

namespace DesignPatterns.Patterns.Factories
{
    /// <summary>Fábrica concreta del modelo Explorer (Ford, rojo).</summary>
    public class ExplorerFactory : VehicleFactory
    {
        protected override Vehicle CreateVehicle()
        {
            return new Car("Red", "Ford", "Explorer");
        }
    }
}
