using Demo.BusinessLogic.DTOs;
using Demo.BusinessLogic.Services;
using Demo.Persentation.ViewModels.DepartmentsViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Persentation.Controllers
{
    public class DepartmentController
        (IDepartmentServices _departmentServices ,
        ILogger<DepartmentController> _logger ,
        IWebHostEnvironment _environment) : Controller
    {
        public IActionResult Index()
        {
            var department = _departmentServices.GetAllDepartments();
            return View();
        }
        [HttpGet]
        #region Create department
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(CreateDepartmentDto createdepartmentDto)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    int res = _departmentServices.CreateDepartment(createdepartmentDto);
                    if (res > 0) return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department Can not be created");
                        return View(createdepartmentDto);
                    }
                }
                catch(Exception ex)
                {
                    if(_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(createdepartmentDto);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                    }
                }
            }
          
                return View(createdepartmentDto);
        }
        #endregion
        #region Dept Detailes

        public IActionResult Detailes(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department is null) return NotFound();
            return View(department);
        }
        #endregion

        #region Edit Dep
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(!id.HasValue)return BadRequest();
            var department = _departmentServices.GetDepartmentById(id.Value);
            /* Map from DepartmentDetailsDto to DepartmentDetailsViewModel*/

            if (department is null) return NotFound();
            else
            {
                var departmentViewModel = new DepartmentEditViewModel()
                {
                    Code = department.Code,
                    Name = department.Name,
                    DateOfCreation = department.DateOfCreation,
                    Description = department.Description
                };
                return View(department);
            }
          
        }
        [HttpPost]
        public IActionResult Edit([FromRoute]int id,DepartmentEditViewModel departmentEditViewModel)
        {
          
            if (!ModelState.IsValid) return View(departmentEditViewModel);
            try
            {
                var updatedept = new UpdateDepartmentDto()
                {
                    Id=id,

                    Name = departmentEditViewModel.Name,
                    Code = departmentEditViewModel.Code,
                    Description = departmentEditViewModel.Description,
                    DateOfCreation = departmentEditViewModel.DateOfCreation,


                };
                var res = _departmentServices.UpdateDepartment(updatedept);
                if (res > 0) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Department Can not be Updated   ");
                   
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
            return View(departmentEditViewModel);
        }

            #endregion
        }
}
