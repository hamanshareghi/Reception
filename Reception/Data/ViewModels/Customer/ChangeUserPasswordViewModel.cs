using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.Customer
{
    public class ChangeUserPasswordViewModel
    {
        [Display(Name = "رمزقدیم")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "لطفا {0} را کمتر از {1} وارد کنید")]
        [DataType(DataType.Password)]

        public string OldPassword { get; set; }
        [Display(Name = "رمزجدید")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "لطفا {0} را کمتر از {1} وارد کنید")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [Display(Name = "تکرار رمزجدید")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "لطفا {0} را کمتر از {1} وارد کنید")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}
