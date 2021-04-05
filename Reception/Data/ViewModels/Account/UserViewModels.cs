using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Model.Entities;

namespace Data.ViewModels.Account
{
    public class CreateModel
    {

        [Display(Name = "نام کامل")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "لطفا {0} را کمتر از {1} وارد کنید")]
        public string FullName { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "لطفا {0} را کمتر از {1} وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "نام کاربری")]
        [MaxLength(100, ErrorMessage = "لطفا {0} را کمتر از {1} وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "لطفا {0} را کمتر از {1} وارد کنید")]
        public string PhoneNumber { get; set; }

        [Display(Name = "نوع کاربر")]
        public UserKind UserKind { get; set; }

        [Display(Name = "پسورد")]
        [MaxLength(100, ErrorMessage = "لطفا {0} را کمتر از {1} وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "نقش")]
        public List<ApplicationRole> Roles { get; set; }

    }



}
