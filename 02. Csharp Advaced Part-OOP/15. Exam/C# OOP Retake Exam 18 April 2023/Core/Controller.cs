using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Repositories.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IUser> users;
        private readonly IRepository<IRoute> routes;
        private readonly IRepository<IVehicle> vehicles;
        public Controller()
        {
            users = new UserRepository();
            routes = new RouteRepository();
            vehicles = new VehicleRepository();
        }
        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            var route = routes.GetAll()
                .FirstOrDefault(x => x.StartPoint == startPoint && x.EndPoint == endPoint && x.Length == length);

            if (route != null)
            {
                return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
            }

            route = routes.GetAll()
                .FirstOrDefault(x => x.StartPoint == startPoint && x.EndPoint == endPoint && x.Length < length);

            if (route != null)
            {
                return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
            }

            route = routes.GetAll()
                .FirstOrDefault(x => x.StartPoint == startPoint && x.EndPoint == endPoint && x.Length > length);

            if (route != null)
            {
                route.LockRoute();
            }

            int countRoutes = routes.GetAll().Count() + 1;
            Route newRoute = new Route(startPoint, endPoint, length, countRoutes);

            routes.AddModel(newRoute);
            return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            IUser user = users.FindById(drivingLicenseNumber);
            IRoute route = routes.FindById(routeId);
            IVehicle vehicle = vehicles.FindById(licensePlateNumber);

            if (user.IsBlocked)
            {
                return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
            }

            if (vehicle.IsDamaged)
            {
                return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
            }

            if (route.IsLocked)
            {
                return string.Format(OutputMessages.RouteLocked, routeId);
            }

            vehicle.Drive(route.Length);

            if (isAccidentHappened)
            {
                vehicle.ChangeStatus();
                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }

            return vehicle.ToString();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            IUser user = users.FindById(drivingLicenseNumber);

            if (user != null)
            {
                return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }

            user = new User(firstName, lastName, drivingLicenseNumber);
            users.AddModel(user);

            return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
        }

        public string RepairVehicles(int count)
        {
            List<IVehicle> vehiclesToRepear = vehicles
                .GetAll()
                .Where(x => x.IsDamaged)
                .OrderBy(b => b.Brand)
                .ThenBy(m => m.Model)
                .Take(count)
                .ToList();

            foreach (Vehicle vehicle in vehiclesToRepear)
            {

                vehicle.ChangeStatus();
                vehicle.Recharge();

            }
            return string.Format(OutputMessages.RepairedVehicles, vehiclesToRepear.Count);
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if (vehicleType != "PassengerCar" && vehicleType != "CargoVan")
            {
                return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }

            IVehicle vehicle = vehicles.FindById(licensePlateNumber);

            if (vehicle != null)
            {
                return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }

            if (vehicleType == "CargoVan")
            {
                vehicle = new CargoVan(brand, model, licensePlateNumber);
            }
            else
            {
                vehicle = new PassengerCar(brand, model, licensePlateNumber);
            }

            vehicles.AddModel(vehicle);
            return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
        }

        public string UsersReport()
        {
            StringBuilder sb = new StringBuilder();
            var userss = users
                .GetAll()
                .OrderByDescending(r => r.Rating)
                .ThenBy(l => l.LastName)
                .ThenBy(f => f.FirstName)
                .ToList();

            sb.AppendLine("*** E-Drive-Rent ***");

            foreach (var user in userss)
            {
                sb.AppendLine(user.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
