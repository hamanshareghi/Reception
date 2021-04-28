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
    public class Sale :BaseEntityNotId
    {
        [Key]
        public int SaleId { get; set; }

        [Display(Name = "مشتری")]
        public string UserId { get; set; }

        [Display(Name = "کاربر")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string CurrentId { get; set; }

        [Display(Name = "تاریخ")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime SaleDate { get; set; }

        [Display(Name = "محصول")]
        public int ProductId { get; set; }

        [Display(Name = "تعداد")]
        public int Count { get; set; }

        [Display(Name = "فروش")]
        public int SalePrice { get; set; }

        [Display(Name = "لینک")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ShortKey { get; set; }

        [Display(Name = "شرح")]
        public string Description { get; set; }

        #region Relation
        [Display(Name = "محصول")]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [Display(Name = "مشتری")]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        

        #endregion
    }
}
