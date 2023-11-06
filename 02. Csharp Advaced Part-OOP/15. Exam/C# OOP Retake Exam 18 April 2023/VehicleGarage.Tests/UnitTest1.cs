using NUnit.Framework;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void VehicleConstructor()
        {
            Vehicle vehicle = new Vehicle("Seat", "Leon", "B3685VN");

            Assert.AreEqual("Seat", vehicle.Brand);
            Assert.AreEqual("Leon", vehicle.Model);
            Assert.AreEqual("B3685VN", vehicle.LicensePlateNumber);
            Assert.AreEqual(100, vehicle.BatteryLevel);
            Assert.IsFalse(vehicle.IsDamaged);
        }

        [Test]
        public void GarageConstructor()
        {
            Garage garage = new Garage(10);

            Assert.AreEqual(0, garage.Vehicles.Count);
            Assert.AreEqual(10, garage.Capacity);

            garage.Vehicles.Add(new Vehicle("Seat", "Leon", "B3685VN"));
            garage.Capacity = 9;

            Assert.AreEqual(1, garage.Vehicles.Count);
            Assert.AreEqual(9, garage.Capacity);
        }

        [Test]
        public void AddVehicle()
        {
            Garage garage = new Garage(1);

            Assert.AreEqual(0, garage.Vehicles.Count);
            Assert.AreEqual(1, garage.Capacity);

            Assert.IsTrue(garage.AddVehicle(new Vehicle("Seat", "Leon", "B3685VN")));
            Assert.AreEqual(1, garage.Vehicles.Count);
            Assert.IsFalse(garage.AddVehicle(new Vehicle("Seat", "Leon", "B3685V555N")));
            garage.Capacity = 2;
            Assert.IsFalse(garage.AddVehicle(new Vehicle("Seat", "Leon", "B3685VN")));
        }

        [Test]
        public void ChargeVehicles()
        {
            Garage garage = new Garage(1);
            Vehicle vehicle = new Vehicle("Seat", "Leon", "B3685VN");
            vehicle.BatteryLevel = 20;
            garage.AddVehicle(vehicle);

            Assert.AreEqual(20, vehicle.BatteryLevel);
            Assert.AreEqual(0, garage.ChargeVehicles(10));
            Assert.AreEqual(20, vehicle.BatteryLevel);
            Assert.AreEqual(1, garage.ChargeVehicles(20));
            Assert.AreEqual(100, vehicle.BatteryLevel);
        }

        [Test]
        public void DriveVehicle()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("Seat1", "Leon1", "B3685VN1");
            Vehicle vehicle2 = new Vehicle("Sea2t", "Leon2", "B3685VN2");
            Vehicle vehicle3 = new Vehicle("Sea3t", "Leon3", "B3685VN3");
            Vehicle vehicle4 = new Vehicle("Sea4t", "Leon4", "B3685VN4");
            Vehicle vehicle5 = new Vehicle("Seat5", "Leon5", "B3685VN5");

            vehicle.IsDamaged = true;
            vehicle2.BatteryLevel = 200;
            vehicle3.BatteryLevel = 2;

            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);
            garage.AddVehicle(vehicle4);
            garage.AddVehicle(vehicle5);

            garage.DriveVehicle("B3685VN1", 30, false);
            Assert.AreEqual(100, vehicle.BatteryLevel);
            Assert.IsTrue(vehicle.IsDamaged);

            garage.DriveVehicle("B3685VN2", 101, false);
            Assert.AreEqual(200, vehicle2.BatteryLevel);
            Assert.IsFalse(vehicle2.IsDamaged);

            garage.DriveVehicle("B3685VN3", 30, false);
            Assert.AreEqual(2, vehicle3.BatteryLevel);
            Assert.IsFalse(vehicle3.IsDamaged);

            garage.DriveVehicle("B3685VN4", 30, false);
            Assert.AreEqual(70, vehicle4.BatteryLevel);
            Assert.IsFalse(vehicle4.IsDamaged);

            garage.DriveVehicle("B3685VN5", 30, true);
            Assert.AreEqual(70, vehicle5.BatteryLevel);
            Assert.IsTrue(vehicle5.IsDamaged);
        }


        [Test]
        public void RepairVehicles()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("Seat1", "Leon1", "B3685VN1");
            Vehicle vehicle2 = new Vehicle("Sea2t", "Leon2", "B3685VN2");
            Vehicle vehicle3 = new Vehicle("Sea3t", "Leon3", "B3685VN3");
            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);

            Assert.AreEqual("Vehicles repaired: 0", garage.RepairVehicles());
            Assert.IsFalse(vehicle.IsDamaged);
            Assert.IsFalse(vehicle2.IsDamaged);
            Assert.IsFalse(vehicle3.IsDamaged);

            vehicle.IsDamaged = true;
            vehicle2.IsDamaged = true;
            vehicle3.IsDamaged = true;

            Assert.IsTrue(vehicle.IsDamaged);
            Assert.IsTrue(vehicle2.IsDamaged);
            Assert.IsTrue(vehicle3.IsDamaged);

            Assert.AreEqual("Vehicles repaired: 3", garage.RepairVehicles());
            Assert.IsFalse(vehicle.IsDamaged);
            Assert.IsFalse(vehicle2.IsDamaged);
            Assert.IsFalse(vehicle3.IsDamaged);
        }
    }
}