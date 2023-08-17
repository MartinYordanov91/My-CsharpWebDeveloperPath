using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Parking
    {
        
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;

            Cars = new();
        }

        public List<Car> Cars { get; set; }
        public int Count { get { return Cars.Count; } }

        public string AddCar(Car car)
        {

            if (Cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (capacity <= Cars.Count)
            {
                return "Parking is full!";
            }

            Cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";

        }
        public string RemoveCar(string registration)
        {
            if (Cars.Any(x => x.RegistrationNumber == registration) == false)
            {
                return $"Car with that registration number, doesn't exist!";
            }

            Car car = Cars.First(x => x.RegistrationNumber == registration);
            Cars.Remove(car);
            return $"Successfully removed {registration}";
        }

        public Car GetCar(string registration)
        {
            Car car = Cars.First(x => x.RegistrationNumber == registration);
            return car;
        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var number in registrationNumbers)
            {
               RemoveCar(number);
            }
        }
    }
}
