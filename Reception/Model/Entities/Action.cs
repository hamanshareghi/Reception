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
    public class Action : BaseEntityNotId
    {
        [Key]
        public int ActionId { get; set; }

        [Display(Name = "پذیرش")]
        public int ReceptionId { get; set; }

        [Display(Name = "خدمات")]
        public int ServiceId { get; set; }

        [Display(Name = "باربری")]
        public int ShippingId { get; set; }

        [Display(Name = "مبلغ")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Price { get; set; }

        [Display(Name = "تاریخ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime ActionDate { get; set; }


        [Display(Name = "شرح")]
        public string Description { get; set; }

        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int StatusId { get; set; }


        #region Relation
        [Display(Name = "پذیرش")]
        [ForeignKey(nameof(ReceptionId))]
        public Reception Reception { get; set; }

        [Display(Name = "خدمات")]
        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; }


        [Display(Name = "باربری")]
        [ForeignKey(nameof(ShippingId))]
        public Shipping Shipping { get; set; }

        [Display(Name = "وضعیت")]
        [ForeignKey(nameof(StatusId))]
        public Status Status { get; set; }
        #endregion

    }
}
