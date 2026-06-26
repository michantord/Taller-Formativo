using DesignPatterns.Models;

namespace DesignPatterns.Patterns.Factories
{
    /// <summary>Fábrica concreta del modelo Mustang (Ford, rojo).</summary>
    public class MustangFactory : VehicleFactory
    {
        protected override Vehicle CreateVehicle()
        {
            return new Car("Red", "Ford", "Mustang");
        }
    }
}
