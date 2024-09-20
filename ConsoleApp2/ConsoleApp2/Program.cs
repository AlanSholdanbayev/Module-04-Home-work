using System;
using System.Collections.Generic;

public class Employee
{
    public string Name { get; set; }
    public double BaseSalary { get; set; }
    public string EmployeeType { get; set; } 
}

public interface ISalaryCalculator
{
    double CalculateSalary(Employee employee);
}

public class PermanentSalaryCalculator : ISalaryCalculator
{
    public double CalculateSalary(Employee employee)
    {
        return employee.BaseSalary * 1.2; 
    }
}

public class ContractSalaryCalculator : ISalaryCalculator
{
    public double CalculateSalary(Employee employee)
    {
        return employee.BaseSalary * 1.1; 
    }
}

public class InternSalaryCalculator : ISalaryCalculator
{
    public double CalculateSalary(Employee employee)
    {
        return employee.BaseSalary * 0.8; 
    }
}

public class FreelancerSalaryCalculator : ISalaryCalculator
{
    public double CalculateSalary(Employee employee)
    {
        return employee.BaseSalary; 
    }
}

public class EmployeeSalaryCalculator
{
    private readonly Dictionary<string, ISalaryCalculator> _salaryCalculators;

    public EmployeeSalaryCalculator()
    {
        _salaryCalculators = new Dictionary<string, ISalaryCalculator>
        {
            { "Permanent", new PermanentSalaryCalculator() },
            { "Contract", new ContractSalaryCalculator() },
            { "Intern", new InternSalaryCalculator() },
            { "Freelancer", new FreelancerSalaryCalculator() }
        };
    }

    public double CalculateSalary(Employee employee)
    {
        if (_salaryCalculators.TryGetValue(employee.EmployeeType, out var calculator))
        {
            return calculator.CalculateSalary(employee);
        }
        else
        {
            throw new NotSupportedException("Employee type not supported");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Employee permanentEmployee = new Employee { Name = "Sasha", BaseSalary = 1000, EmployeeType = "Permanent" };
        Employee contractEmployee = new Employee { Name = "Masha", BaseSalary = 1000, EmployeeType = "Contract" };
        Employee internEmployee = new Employee { Name = "Yasha", BaseSalary = 1000, EmployeeType = "Intern" };
        Employee freelancerEmployee = new Employee { Name = "Love", BaseSalary = 1000, EmployeeType = "Freelancer" };

        EmployeeSalaryCalculator salaryCalculator = new EmployeeSalaryCalculator();

        Console.WriteLine($"{permanentEmployee.Name}: {salaryCalculator.CalculateSalary(permanentEmployee)}");
        Console.WriteLine($"{contractEmployee.Name}: {salaryCalculator.CalculateSalary(contractEmployee)}");
        Console.WriteLine($"{internEmployee.Name}: {salaryCalculator.CalculateSalary(internEmployee)}");
        Console.WriteLine($"{freelancerEmployee.Name}: {salaryCalculator.CalculateSalary(freelancerEmployee)}");
    }
}