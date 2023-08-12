using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            Traveled = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public int Traveled { get; set; }

        public void Drive(int amountOfKm)
        {
            if (amountOfKm  * FuelConsumptionPerKilometer <= FuelAmount)
            {
                FuelAmount -= amountOfKm* FuelConsumptionPerKilometer;
                Traveled += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString() =>
            $"{Model} {FuelAmount:f2} {Traveled}";
    }
}
