namespace Vehicles.Core
{
    using Interface;
    using Vehicles.Models.Vehicle;

    public class Engine : IEngine
    {


        private Vehicle car;
        private Vehicle truck;
        private Vehicle bus;

        public Engine(Vehicle car, Vehicle truck, Vehicle bus)
        {
            this.car = car;
            this.truck = truck;
            this.bus = bus;
        }

        public void Run()
        {
            int comands = int.Parse(Console.ReadLine());

            for (int i = 0; i < comands; i++)
            {
                string[] curentcomand = Console.ReadLine()
                    .Split();
                try
                {
                    if (curentcomand[0] == "Drive")
                    {
                        if (curentcomand[1] == "Car")
                        {
                            Console.WriteLine(this.car.Drive(double.Parse(curentcomand[2])));
                        }
                        else if (curentcomand[1] == "Truck")
                        {
                            Console.WriteLine(this.truck.Drive(double.Parse(curentcomand[2])));
                        }
                        else if (curentcomand[1] == "Bus")
                        {
                            Console.WriteLine(this.bus.Drive(double.Parse(curentcomand[2])));
                        }

                    }
                    else if (curentcomand[0] == "Refuel")
                    {
                        if (curentcomand[1] == "Car")
                        {
                            this.car.Refuel(double.Parse(curentcomand[2]));
                        }
                        else if (curentcomand[1] == "Truck")
                        {
                            this.truck.Refuel(double.Parse(curentcomand[2]));
                        }
                        else if (curentcomand[1] == "Bus")
                        {
                            this.bus.Refuel(double.Parse(curentcomand[2]));
                        }

                    }
                    else if (curentcomand[0] == "DriveEmpty")
                    {
                        Bus buss = bus as Bus;
                        if (buss != null)
                        {
                            Console.WriteLine(buss.DriveEmty(double.Parse(curentcomand[2])));

                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
