using DesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Repositories
{
    public class MyVehiclesRepository : IVehicleRepository
    {
        private readonly ICollection<Vehicle> _memoryCollection;

        public MyVehiclesRepository()
        {
            _memoryCollection = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _memoryCollection.Add(vehicle);
        }

        public Vehicle Find(string id)
        {
           return  _memoryCollection.FirstOrDefault(v => v.ID.Equals(new Guid(id)));
        }

        public ICollection<Vehicle> GetVehicles()
        {
            return _memoryCollection;
        }

        
    }
}
