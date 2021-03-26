using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Model.Entities.Common;

namespace Model.Entities
{
    public class Message :BaseEntity<int>
    {

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Title { get; set; }

        [Display(Name = "متن")]
        public string Text { get; set; }

        [Display(Name = "تصویر")]
        public string Image { get; set; }

    }
}
