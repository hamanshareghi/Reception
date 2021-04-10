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
    public class Debtor : BaseEntityNotId
    {
        [Key]
        public int DebtorId { get; set; }
        [Display(Name = "مشتری")]
        public string UserId { get; set; }

        [Display(Name = "کاربر")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string CurrentUser { get; set; }

        [Display(Name = "بابت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Title { get; set; }

        [Display(Name = "مبلغ")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Price { get; set; }

        [Display(Name = "شرح")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Description { get; set; }

        [Display(Name = "وضعیت")]
        public PayStatus PayStatus { get; set; }

        #region Relation
        [Display(Name = "کاربر")]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        #endregion
    }

    public enum PayStatus
    {
        Paid=1,
        NotPaid =2
    }
}
