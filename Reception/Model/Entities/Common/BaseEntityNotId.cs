using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Entities.Common
{
    public class BaseEntityNotId
    {

        [Display(Name = "تاریخ")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]

        public DateTime InsertDate { get; set; } = DateTime.Now;

        public bool IsDelete { get; set; }

        [Display(Name = "تاریخ")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]

        public DateTime? UpDateTime { get; set; }
    }
}
