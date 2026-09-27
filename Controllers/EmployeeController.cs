using EmployeeApp.Models;
using EmployeeApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers;

public class EmployeeController : Controller
{
    private readonly EmployeeService _employeeService;

    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var employees = _employeeService.GetAll();

        return View(employees);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Employee employee)
    {
        var result = _employeeService.Create(employee);

        return Json(new
        {
            success = result.Success,
            message = result.Message
        });
    }
}