﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.DTOs.EmployeeDtos
{
    public class EmployeeDetailesDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public string? Address { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
      
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
        #region Members to Configer
        public DateOnly HiringDate { get; set; }
        public string Gender { get; set; }
        public string EmployeeType { get; set; }
        #endregion

        public int? DepartmentId { get; set; }

        public string ? Department { get; set; }

        public string? ImageName { get; set; }
    }

}
