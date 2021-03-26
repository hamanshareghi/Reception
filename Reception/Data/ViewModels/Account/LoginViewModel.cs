using System.ComponentModel.DataAnnotations;

namespace Data.ViewModels.Account
{
    public class LoginViewModel
    {

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "پسورد")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "به خاطربسپار؟")]
        public bool RememberMe { get; set; }

    }
}
