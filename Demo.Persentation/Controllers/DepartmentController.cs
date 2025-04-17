//using Demo.BusinessLogic.DTOs;
using Demo.BusinessLogic.DTOs.DepartmentDtos;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.Persentation.ViewModels.DepartmentsViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Persentation.Controllers
{
    public class DepartmentController
        (IDepartmentService _departmentServices ,
        ILogger<DepartmentController> _logger ,
        IWebHostEnvironment _environment) : Controller
    {
        public IActionResult Index()
        {
            //ViewData["sms01"] = "Hi from Department Index => ViewData";
            //ViewBag.sms01 = "Hi from Department Index => ViewBag";


            var department = _departmentServices.GetAllDepartments();
            return View(department);
        }
        [HttpGet]
        #region Create department
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(DepartmentViewModel departmentViewModel)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var createdepartmentDto = new CreateDepartmentDto()
                    {
                        Name = departmentViewModel.Name,
                        Code = departmentViewModel.Code,
                        DateOfCreation = departmentViewModel.DateOfCreation,
                        Description = departmentViewModel.Description,


                    };
                    int res = _departmentServices.CreateDepartment(createdepartmentDto);
                    var sms=string.Empty;
                    if (res > 0) return RedirectToAction(nameof(Index));
                    else sms = "Department can not be created";


                    ViewData["sms01"] = sms;
                    TempData["sms02"] = new CreateDepartmentDto() { Description=sms};
    
                }
                catch (Exception ex)
                {
                    if(_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                       
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                    }
                }
            }
          
                return View(departmentViewModel);
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
                var departmentViewModel = new DepartmentViewModel()
                {
                    Code = department.Code,
                    Name = department.Name,
                    DateOfCreation = department.DateOfCreation,
                    Description = department.Description
                };
                return View(department);
            }
          
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit([FromRoute]int id,DepartmentViewModel departmentEditViewModel)
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
        #region Delete 
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            var department = _departmentServices.GetDepartmentById(Id.Value);
            if(department is null)
            {
                return NotFound();
            }
            else
            {
                return View(department);
            }
        }
        [HttpPost]
        public IActionResult Delete([FromRoute] int id, DepartmentViewModel departmentEditViewModel)
        {
            if (id == 0) return BadRequest();
            try 
            {

                var IsDeleted = _departmentServices.DeletedDepartment(id);
                if (IsDeleted) return RedirectToAction(nameof(Index));
                ModelState.AddModelError(string.Empty, "Deparment Cant Be Deleted");

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
            return RedirectToAction(nameof(Delete), new {id=id});

        }
            #endregion
        }
}
