namespace Demo.Persentation.ViewModels.DepartmentsViewModels
{
    public class DepartmentEditViewModel
    {
        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime? DateOfCreation { get; set; }
    }
}
