using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities.Common;

namespace Model.Entities
{
    public class Reception : BaseEntityNotId
    {
        [Key]
        [Display(Name = "پذیرش")]
        public int ReceptionId { get; set; }

        [Display(Name = "مشتری")]
        public string CustomerId { get; set; }

        [Display(Name = "دستگاه")]
        public int ProductId { get; set; }

        [Display(Name = "سریال")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Serial { get; set; }

        //[Display(Name = "ایرادات")]
        //public int DeviceDefectId { get; set; }
        //[Display(Name = "تصاویر")]
        //public int DeviceImageId { get; set; }

        [Display(Name = "کاربر")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]

        public string UserId { get; set; }

        [Display(Name = "پذیرش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime ReceptionDate  { get; set; }

        [Display(Name = "شرح")]
        public string Description { get; set; }

        [Display(Name = "وضعیت")]
        public ReceptionStatus ReceptionStatus { get; set; }

        [Display(Name = "پذیرش")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        #region Relation

        [Display(Name = "دستگاه")]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }


        [Display(Name = "مشتری")]
        [ForeignKey(nameof(CustomerId))]
        public ApplicationUser Customer { get; set; }


        public ICollection<Duty> Duties { get; set; }

        public ICollection<DeviceDefect> DeviceDefects { get; set; }
        public ICollection<DeviceImage> DeviceImages { get; set; }
        //public ICollection<Sms> SmsCollection { get; set; }

        #endregion

    }


    public enum ReceptionStatus
    {
        Done=1,
        NotYet =0
    }
}
