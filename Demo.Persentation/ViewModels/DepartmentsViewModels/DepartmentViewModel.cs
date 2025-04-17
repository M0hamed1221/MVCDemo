using System.ComponentModel.DataAnnotations;

namespace Demo.Persentation.ViewModels.DepartmentsViewModels
{
    public class DepartmentViewModel
    {
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Code Is Required")]

        public string Code { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime DateOfCreation { get; set; }
    }
}
