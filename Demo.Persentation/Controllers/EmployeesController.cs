using AutoMapper;
using Demo.BusinessLogic.DTOs.DepartmentDtos;
using Demo.BusinessLogic.DTOs.EmployeeDtos;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Models.EmployeeModels;
using Demo.DataAccess.Models.SharedModel;
using Demo.DataAccess.Repositoriers.Interfaces;
using Demo.Persentation.ViewModels.DepartmentsViewModels;
using Demo.Persentation.ViewModels.EmployeesViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Persentation.Controllers
{
    public class EmployeesController(IEmployeeService _employeeService,
        ILogger<DepartmentController> _logger,
        IWebHostEnvironment _environment 
        )
        : Controller
    {
        public IActionResult Index(string? EmployeeSearchName)
        {
            var emps = _employeeService.GetAllEmployees(EmployeeSearchName);
                //.Where(e => e.Name.Contains(EmployeeSearchName));
            return View(emps);
        }
        #region create Employee
        [HttpGet]
        public IActionResult Create([FromServices]IDepartmentService _departmentService)
        {
            ViewData["Departments"]=_departmentService.GetAllDepartments();
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var createEmployeeDto = new CreateEmployeeDto()
                    {
                        DepartmentId = employeeViewModel.DepartmentId,
                        Name = employeeViewModel.Name,
                        Salary=employeeViewModel.Salary,
                        HiringDate = employeeViewModel.HiringDate,
                        Address=employeeViewModel.Address,
                        Age=employeeViewModel.Age,
                        Gender=employeeViewModel.Gender,
                        Email=employeeViewModel.Email,
                        EmployeeType=employeeViewModel.EmployeeType,
                        IsActive=employeeViewModel.IsActive,
                        PhoneNumber=employeeViewModel.PhoneNumber,


                    };
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
                  
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                    }
                }
            }

            return View(employeeViewModel);
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
        #region Edit Emp
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var emp = _employeeService.GetEmployeeById(id.Value);
            /* Map from DepartmentDetailsDto to DepartmentDetailsViewModel*/

            if (emp is null) return NotFound();
            else
            {
                var employeeViewModel = new EmployeeViewModel()
                {
                   Name=emp.Name,
                   Address=emp.Address,
                   Age=emp.Age,
                   Email=emp.Email,
                   HiringDate=emp.HiringDate,
                   PhoneNumber=emp.PhoneNumber,
                   IsActive=emp.IsActive,
                   Salary=emp.Salary,
                   Gender=Enum.Parse<Gender>(emp.Gender),
                   EmployeeType= Enum.Parse<EmployeeType>(emp.EmployeeType),
                    DepartmentId =emp.DepartmentId
                };
                return View(emp);
            }

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, EmployeeViewModel emp)
        {

            if (!ModelState.IsValid) return BadRequest();
            if (!ModelState.IsValid) return View(emp);

            try
            {
                var updateEmployeeDto = new UpdateEmployeeDto()
                {
                    Id = id.Value,
                    Name = emp.Name,
                    Address = emp.Address,
                    Age = emp.Age,
                    Email = emp.Email,
                    HiringDate = emp.HiringDate,
                    PhoneNumber = emp.PhoneNumber,
                    IsActive = emp.IsActive,
                    Salary = emp.Salary,
                    Gender = emp.Gender,
                    EmployeeType = emp.EmployeeType,
                    DepartmentId = emp.DepartmentId
                };
                var res = _employeeService.UpdateEmployee(updateEmployeeDto);
                if (res > 0) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee Can not be Updated   ");

                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);

                }
                else
                {
                    _logger.LogError(ex.Message);
                }

            }
            return View(emp);
        }

        #endregion
    }
}   
