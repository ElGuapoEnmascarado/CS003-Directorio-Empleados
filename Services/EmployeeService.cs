using EmployeeApp.Models;
using EmployeeApp.Repositories;

namespace EmployeeApp.Services;

public class EmployeeService
{
    private readonly EmployeeRepository _employeeRepository;

    public EmployeeService(EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public List<Employee> GetAll()
    {
        return _employeeRepository.GetAll();
    }

    public (bool Success, string Message) Create(Employee employee)
    {
        if (employee == null)
            return (false, "Los datos del empleado son obligatorios.");

        if (string.IsNullOrWhiteSpace(employee.Name))
            return (false, "El nombre es obligatorio.");

        if (string.IsNullOrWhiteSpace(employee.Position))
            return (false, "El puesto es obligatorio.");

        if (employee.Salary <= 0)
            return (false, "El salario debe ser mayor a cero.");

        if (string.IsNullOrWhiteSpace(employee.Department))
            return (false, "El departamento es obligatorio.");

        employee.Name = employee.Name.Trim();
        employee.Position = employee.Position.Trim();
        employee.Department = employee.Department.Trim();

        _employeeRepository.Add(employee);

        return (true, "Empleado registrado correctamente.");
    }
}