using System.ComponentModel.DataAnnotations;

namespace Demo.Persentation.ViewModels.AccountViewModels
{
    public class RestPasswordViewModel
    {
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
