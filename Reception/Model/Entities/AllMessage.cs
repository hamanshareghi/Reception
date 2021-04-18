using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Entities.Common;

namespace Model.Entities
{
    public class AllMessage : BaseEntityNotId
    {
        [Key]
        public int SmsId { get; set; }

        [Display(Name = "کاربر")]
        public string CurrentUserId { get; set; }

        [Display(Name = "مشتری")]
        public string UserId { get; set; }

        [Display(Name = "تاریخ")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime SmsDate { get; set; }
        [Display(Name = "نوع")]
        public SmsKind  Kind { get; set; }

        [Display(Name = "شرح")]
        public string Description { get; set; }

        [Display(Name = "وضعیت")]
        public string SmsStatus { get; set; }

        #region Relation
        [Display(Name = "مشتری")]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser Users { get; set; }

        #endregion

    }

    public enum SmsKind
    {
        Customer=1,
        Debtor=2,
        Reception=3,
        Duty=4,
        Cost=5,
        RequestDevice=6,
        Leave=7,
        Shipping=8,
        Ticket=9,
        Service=10
    }

}
