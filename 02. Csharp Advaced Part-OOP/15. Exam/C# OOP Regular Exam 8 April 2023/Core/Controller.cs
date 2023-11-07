using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Linq;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IRepository<ISupplement> supplements;
        private IRepository<IRobot> robots;
        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }
        public string CreateRobot(string model, string typeName)
        {
            if (typeName != "DomesticAssistant" && typeName != "IndustrialAssistant")
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }
            IRobot robot = null;

            if (typeName == "DomesticAssistant")
            {
                robot = new DomesticAssistant(model);
            }
            else
            {
                robot = new IndustrialAssistant(model);
            }

            robots.AddNew(robot);
            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != "SpecializedArm" && typeName != "LaserRadar")
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            ISupplement supplement = null;

            if (typeName == "SpecializedArm")
            {
                supplement = new SpecializedArm();
            }
            else
            {
                supplement = new LaserRadar();
            }

            supplements.AddNew(supplement);
            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            var robotColect = robots.Models()
                .Where(x => x.InterfaceStandards.Contains(intefaceStandard))
                .OrderByDescending(x => x.BatteryLevel)
                .ToList();

            if (robotColect.Count == 0)
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            int sumOfBateriPower = robotColect.Sum(x => x.BatteryLevel);

            if (sumOfBateriPower < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - sumOfBateriPower);
            }

            int countrobots = 0;

            while (totalPowerNeeded != 0)
            {
                IRobot robot = robotColect.FirstOrDefault();
                if (robot.BatteryLevel < totalPowerNeeded)
                {
                    totalPowerNeeded -= robot.BatteryLevel;
                    robot.ExecuteService(robot.BatteryLevel);
                    countrobots++;
                }
                else
                {
                    robot.ExecuteService(totalPowerNeeded);
                    totalPowerNeeded = 0;
                    countrobots++;
                }
                robotColect.Remove(robot);
            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, countrobots);
        }

        public string Report()
        {
            var robotColection = robots.Models()
                .OrderByDescending(x=>x.BatteryLevel)
                .ThenBy(x=>x.BatteryCapacity)
                .ToList();

            return string.Join(Environment.NewLine, robotColection);
        }

        public string RobotRecovery(string model, int minutes)
        {
            var robotColection = robots.Models()
                .Where(x => x.Model == model)
                .Where(x => x.BatteryLevel < (x.BatteryCapacity / 2))
                .ToList();

            foreach (var robot in robotColection)
            {
                robot.Eating(minutes);
            }

            return string.Format(OutputMessages.RobotsFed, robotColection.Count);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements.Models().FirstOrDefault(x => x.GetType().Name == supplementTypeName);
            int interfaceValue = supplement.InterfaceStandard;

            var robotsColect = robots.Models()
                .Where(x => !x.InterfaceStandards.Contains(interfaceValue))
                .Where(x => x.Model == model)
                .ToList();

            if (robotsColect.Count == 0)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }

            IRobot robot = robotsColect.FirstOrDefault();
            robot.InstallSupplement(supplement);
            supplements.RemoveByName(supplementTypeName);
            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
        }
    }
}
