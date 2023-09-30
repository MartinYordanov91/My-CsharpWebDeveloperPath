namespace Vehicles.Core
{
    using Interface;
    using Vehicles.Models.Vehicle;

    public class Engine : IEngine
    {


        private Vehicle car;
        private Vehicle truck;

        public Engine(Vehicle car, Vehicle truck)
        {
            this.car = car;
            this.truck = truck;
        }

        public void Run()
        {
            int comands = int.Parse(Console.ReadLine());

            for (int i = 0; i < comands; i++)
            {
                string[] curentcomand = Console.ReadLine()
                    .Split();

                if (curentcomand[0] == "Drive")
                {
                    if (curentcomand[1] == "Car")
                    {
                        Console.WriteLine(car.Drive(double.Parse(curentcomand[2])));
                    }
                    else if (curentcomand[1] == "Truck")
                    {
                        Console.WriteLine(truck.Drive(double.Parse(curentcomand[2])));
                    }
                }
                else if (curentcomand[0] == "Refuel")
                {
                    if (curentcomand[1] == "Car")
                    {
                        car.Refuel(double.Parse(curentcomand[2]));
                    }
                    else if (curentcomand[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(curentcomand[2]));
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
