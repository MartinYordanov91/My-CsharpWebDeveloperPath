using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public RepairShop(int capacity)
        {
            this.Capacity = capacity;
            this.Vehicles = new();
        }

        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public int GetCount () { return this.Vehicles.Count; }

        public void AddVehicle(Vehicle vehicle)
        {
            if(this.Vehicles.Count < this.Capacity)
            {
                this.Vehicles.Add(vehicle);
            }
        }

        public bool RemoveVehicle(string vin)
        {
            if(this.Vehicles.Any(x => x.VIN == vin))
            {
                Vehicle remulve = this.Vehicles.First(x => x.VIN == vin);
                this.Vehicles.Remove(remulve);
                return true;
            }
            return false;
        }
        public Vehicle GetLowestMileage()
        {
            return Vehicles.OrderBy(x =>x.Mileage).First();
        }

        public string Report()
        {
            StringBuilder sb = new();
            sb.AppendLine("Vehicles in the preparatory:");
            foreach (var vehicle in this.Vehicles)
            {
                sb.AppendLine(vehicle.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
