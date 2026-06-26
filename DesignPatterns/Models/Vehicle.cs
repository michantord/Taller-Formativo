using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Models
{
    public abstract class Vehicle : IVehicle
    {
        #region Private properties
        private bool _isEngineOn { get; set; }
        #endregion

        #region Properties
        public readonly Guid ID;
        public virtual int Tires { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Gas { get; set; }
        public double FuelLimit { get; set; }

        // Solicitado por el equipo de negocio: año del vehículo.
        public int Year { get; set; }

        // Bolsa de propiedades por defecto (clave -> valor).
        // El negocio pidió "20 propiedades más por defecto" que llegarán el próximo sprint.
        // En lugar de agregar 20 columnas/propiedades fijas a la clase (lo que obligaría a
        // modificarla y recompilar cada vez), usamos un diccionario flexible. Así, agregar
        // una nueva propiedad por defecto el próximo sprint NO requiere cambiar esta clase:
        // solo se añade una clave más en el Builder. (Principio Abierto/Cerrado - SOLID).
        public IDictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();

        #endregion

        #region Constructors

        public Vehicle(string color, string brand, string model, double fuelLimit = 10)
        {
            ID = Guid.NewGuid();
            Color = color;
            Brand = brand;
            Model = model;
            FuelLimit = fuelLimit;
        }

        #endregion

        #region Methods
        public void AddGas()
        {
            if(Gas <= FuelLimit)
            {
                Gas += 0.1;
            }
            else
            {
                throw new Exception("Gas Full");
            }
        }
        public void StartEngine()
        {
            if (_isEngineOn)
            {
                throw new Exception("Engine is already on");
            }
            if (NeedsGas())
            {
                throw new Exception("No enoguht gas. You need to go to Gas Station");
            }
            _isEngineOn = true;
        }

        public bool NeedsGas()
        {
            return !(Gas > 0);
        }

        public bool IsEngineOn()
        {
            return _isEngineOn;
        }

        public void StopEngine()
        {
            if (!_isEngineOn)
            {
                throw new Exception("Enigne already stopped");
            }

            _isEngineOn = false;
        }

        #endregion

    }
}
