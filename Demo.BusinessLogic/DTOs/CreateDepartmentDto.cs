using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.DTOs
{
    public class CreateDepartmentDto
    {
        [Required(ErrorMessage ="Name Is Required")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Code Is Required")]

        public string Code { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime? DateOfCreation { get; set; }

    }
}
