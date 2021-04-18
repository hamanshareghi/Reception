﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Data.ViewModels.Customer
{
    public class ShowInfoViewModel
    {
        [Display(Name = "نام کامل")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string FullName { get; set; }

        [Display(Name = "تماس")]
        [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Contact { get; set; }

        [Display(Name = "آدرس")]
        [StringLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Address { get; set; }

        [Display(Name = "شرح")]
        public string Description { get; set; }

        [Display(Name = "ثبت")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]

        public DateTime InsertDate { get; set; } = DateTime.Now;

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "بروزرسانی")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]

        public DateTime? UpDateTime { get; set; }
    }
}
