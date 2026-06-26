using DesignPatterns.Models;

namespace DesignPatterns.Patterns.Factories
{
    /// <summary>
    /// Fábrica concreta del NUEVO modelo solicitado: Escape (Ford, rojo).
    ///
    /// Nótese que para agregar este modelo NO hubo que modificar ninguna fábrica existente
    /// ni el modelo Vehicle: solo se creó esta nueva clase. Eso es exactamente la ventaja
    /// del patrón Factory Method que pidió el Arquitecto de Software.
    /// </summary>
    public class EscapeFactory : VehicleFactory
    {
        protected override Vehicle CreateVehicle()
        {
            return new Car("Red", "Ford", "Escape");
        }
    }
}
