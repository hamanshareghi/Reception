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
    public class Cost : BaseEntity<int>
    {
        [Key]
        public int CostId { get; set; }

        [Display(Name = "هزینه")]
        public int CostDefineId { get; set; }

        [Display(Name = "مبلغ")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Price { get; set; }

        [Display(Name = "کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserId { get; set; }

        [Display(Name = "شرح")]
        public string Description { get; set; }

        #region Relation
        [Display(Name = "هزینه")]
        [ForeignKey(nameof(CostDefineId))]
        public CostDefine CostDefine { get; set; }

        //[Display(Name = "کاربر")]
        //[ForeignKey(nameof(UserId))]
        //public ApplicationUser User { get; set; }
        #endregion

    }
}
