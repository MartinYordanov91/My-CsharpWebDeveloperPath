using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Text;
using System.Xml.Linq;

namespace SoftUni;

public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniContext context = new SoftUniContext();
        var result = RemoveTown(context);
        Console.WriteLine(result);

    }


    // Solve -> 03 Employees Full Information
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .OrderBy(e => e.EmployeeId)
            .ToList();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}");
        }
        return sb.ToString().TrimEnd();
    }


    // Solve -> 04 Employees with Salary Over 50 000
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {

        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
           .Where(e => e.Salary > 50000)
           .OrderBy(e => e.FirstName)
           .Select(e => new
           {
               e.FirstName,
               e.Salary
           })
           .ToList();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} - {e.Salary:F2}");
        }

        return sb.ToString().TrimEnd();
    }


    // Solve -> 05 Employees from Research and Development
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
           .Where(e => e.Department.Name == "Research and Development")
           .OrderBy(e => e.Salary)
           .ThenByDescending(e => e.FirstName)
           .Select(e => new
           {
               e.FirstName,
               e.LastName,
               DepartmentName = e.Department.Name,
               e.Salary
           })
           .ToList();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}");
        }

        return sb.ToString().TrimEnd();
    }

    // Solve -> 06 Adding a New Address and Updating Employee
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var newAddress = new Address()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };

        var nakovEmployee = context.Employees
            .FirstOrDefault(e => e.LastName == "Nakov");

        nakovEmployee.Address = newAddress;
        context.SaveChanges();


        var employees = context.Employees
            .OrderByDescending(e => e.AddressId)
            .Select(e => new { employeeAddress = e.Address.AddressText })
            .Take(10)
            .ToList();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.employeeAddress}");
        }
        return sb.ToString().TrimEnd();
    }

    // Solve -> 07 Employees and Projects
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManagerName = $"{e.Manager!.FirstName} {e.Manager.LastName}",
                Projects = e.EmployeesProjects
                            .Where(e => e.Project.StartDate.Year >= 2001 && e.Project.StartDate.Year <= 2003)
                             .Select(e => new
                             {
                                 ProjectName = e.Project.Name,
                                 StartDate = e.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                                 EndDate = e.Project.EndDate.HasValue
                                         ? e.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt")
                                         : "not finished"
                             })
                             .ToList()

            })
            .Take(10)
            .ToList();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerName}");


            foreach (var p in e.Projects)
            {
                sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
            }
        }


        return sb.ToString().TrimEnd();
    }

    // Solve -> 08 Addresses by Town
    public static string GetAddressesByTown(SoftUniContext context)
    {
        StringBuilder sb = new();

        var addresses = context.Addresses
            .Select(e => new
            {
                e.AddressText,
                TownName = e.Town.Name,
                CountOfEmployee = e.Employees.Count
            })
            .OrderByDescending(e => e.CountOfEmployee)
            .ThenBy(e => e.TownName)
            .ThenBy(e => e.AddressText)
            .Take(10)
            .ToList();

        foreach (var e in addresses)
        {
            sb.AppendLine($"{e.AddressText}, {e.TownName} - {e.CountOfEmployee} employees");
        }

        return sb.ToString().TrimEnd();
    }

    // Solve -> 09 Employee 147
    public static string GetEmployee147(SoftUniContext context)
    {
        var sb = new StringBuilder();

        var employee147 = context.Employees
            .Where(e => e.EmployeeId == 147)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                Projects = e.EmployeesProjects.Select(e => new
                {
                    ProjectName = e.Project.Name
                })
                .OrderBy(e => e.ProjectName)
                .ToList()

            }).FirstOrDefault();

        sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

        foreach (var p in employee147.Projects)
        {
            sb.AppendLine($"{p.ProjectName}");
        }
        return sb.ToString().TrimEnd();
    }

    // Solve -> 10 Departments with More Than 5 Employees
    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        var sb = new StringBuilder();

        var departamentsFiltered = context.Departments
            .Where(d => d.Employees.Count() > 5)
            .Select(d => new
            {
                DepartmentName = d.Name,
                ManagerFirstName = d.Manager.FirstName,
                ManagerLastName = d.Manager.LastName,
                Employees = d.Employees
                            .Select(e => new
                            {
                                e.FirstName,
                                e.LastName,
                                e.JobTitle
                            })
                            .OrderBy(e => e.FirstName)
                            .ThenBy(e => e.LastName)
                            .ToList()
            })
            .OrderBy(d => d.Employees.Count())
            .ThenBy(d => d.DepartmentName)
            .ToList();

        foreach (var d in departamentsFiltered)
        {
            sb.AppendLine($"{d.DepartmentName} - {d.ManagerFirstName} {d.ManagerLastName}");

            foreach (var e in d.Employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    // Solve -> 11 Find Latest 10 Projects
    public static string GetLatestProjects(SoftUniContext context)
    {
        var sb = new StringBuilder();

        var last10Projects = context.Projects
            .OrderByDescending(d => d.StartDate)
            .Take(10)
            .Select(p => new
            {
                p.Name,
                p.Description,
                p.StartDate
            })
            .OrderBy(p => p.Name)
            .ToList();

        foreach (var p in last10Projects)
        {
            sb.AppendLine(p.Name);
            sb.AppendLine(p.Description);
            sb.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
        }

        return sb.ToString().TrimEnd();
    }

    // Solve -> 12 Increase Salaries
    public static string IncreaseSalaries(SoftUniContext context)
    {
        var sb = new StringBuilder();

        var promotedEmployes = context.Employees
            .Where(e => e.Department.Name == "Engineering"
                     || e.Department.Name == "Tool Design"
                     || e.Department.Name == "Marketing"
                     || e.Department.Name == "Information Services")
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToList();

        foreach (var e in promotedEmployes)
        {
            e.Salary *= 1.12m;
            sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
        }
        context.SaveChanges();

        return sb.ToString().TrimEnd();
    }

    // Solve -> 13  Find Employees by First Name Starting With Sa
    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        var sb = new StringBuilder();

        var employees = context.Employees
            .Where(e => e.FirstName.ToLower().StartsWith("sa"))
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                e.Salary
            })
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToList();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
        }

        return sb.ToString().TrimEnd();
    }

    // Solve -> 14 Delete Project by Id
    public static string DeleteProjectById(SoftUniContext context)
    {
        var sb = new StringBuilder();

        var projectEmployees = context.EmployeesProjects.Where(e => e.ProjectId == 2).ToList();

        foreach (var p in projectEmployees)
        {
            context.EmployeesProjects.Remove(p);
        }
        context.Projects.Remove(context.Projects.Find(2));
        context.SaveChanges();

        var firstThenProjects = context.Projects.Take(10).Select(p => new { p.Name }).ToList();

        foreach (var p in firstThenProjects)
        {
            sb.AppendLine(p.Name);
        }
    
        return sb.ToString().TrimEnd();
    }

    // Solve -> 15 Remove Town
    public static string RemoveTown(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        
        var employees = context.Employees
            .Include(e => e.Address)
            .ThenInclude(a => a.Town)
            .Where(e => e.Address.Town.Name == "Seattle")
            .ToList();

        foreach (var e in employees)
        {
            e.AddressId = null;
        }
        context.SaveChanges();

        var addressesForDelete = context.Addresses
            .Include(a => a.Town)
            .Where(a => a.Town.Name == "Seattle")
            .ToList();
        var countAddresses = addressesForDelete.Count;

        context.Addresses.RemoveRange(addressesForDelete);
        context.SaveChanges();

        var town = context.Towns
            .Where(t => t.Name == "Seattle")
            .FirstOrDefault();
        if (town != null)
        {
            context.Towns.Remove(town);
            context.SaveChanges();
        }

        sb.AppendLine($"{countAddresses} addresses in Seattle were deleted");
        return sb.ToString().TrimEnd();
    }

}
