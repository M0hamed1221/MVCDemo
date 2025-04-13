using AutoMapper;
using Demo.BusinessLogic.DTOs.DepartmentDtos;
using Demo.BusinessLogic.DTOs.EmployeeDtos;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Repositoriers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Persentation.Controllers
{
    public class EmployeesController(IEmployeeService _employeeService,
        ILogger<DepartmentController> _logger,
        IWebHostEnvironment _environment)
        : Controller
    {
        public IActionResult Index()
        {
            var emps = _employeeService.GetAllEmployees();
            return View(emps);
        }
        #region create Employee
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateEmployeeDto createEmployeeDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int res = _employeeService.CreateEmployee(createEmployeeDto);
                    if (res > 0) return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee Can not be created");
                        return View(createEmployeeDto);
                    }
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(createEmployeeDto);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                    }
                }
            }

            return View(createEmployeeDto);
        }
        #endregion
        #region Empolyee Details
        [HttpGet]
        public IActionResult Detailes(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var emp = _employeeService.GetEmployeeById(id.Value);
            if (emp is null) return NotFound();
            return View(emp);
        }
        #endregion
    }
}   
