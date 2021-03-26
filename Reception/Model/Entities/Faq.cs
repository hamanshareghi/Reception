using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Model.Entities.Common;

namespace Model.Entities
{
    public class Faq : BaseEntityNotId
    {

        [Key]
        public int FaqId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]

        public string FaqTitle { get; set; }

        [Display(Name = "پاسخ")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]

        public string FaqAnswer { get; set; }

        [Display(Name = "کاربر")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserId { get; set; }

    }
}
