using System.ComponentModel.DataAnnotations;

namespace Demo.Persentation.ViewModels.AccountViewModels
{
    public class ForgetPasswordViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
    }
}
