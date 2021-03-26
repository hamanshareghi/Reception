using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Model.Entities;


namespace Data.ViewModels.Account
{
    public class RegisterViewModel
    {
        //[Display(Name = "ایمیل")]
        //[Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        //[MaxLength(100, ErrorMessage = "لطفا {0} را کمتر از {1} وارد کنید")]
        //public string Email { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "لطفا {0} را کمتر از {1} وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "پسورد")]
        [MaxLength(100, ErrorMessage = "لطفا {0} را کمتر از {1} وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "تکرار پسورد")]
        [MaxLength(100, ErrorMessage = "لطفا {0} را کمتر از {1} وارد کنید")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Display(Name = "نقش")]
        public List<ApplicationRole> Roles { get; set; }
    }
}
