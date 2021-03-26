using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Model.Entities.Common;

namespace Model.Entities
{
    public class Product : BaseEntityNotId
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "گروه ")]
        public int ProductGroupId { get; set; }

        [Display(Name = "گروه اصلی")]
        public int? ParentId { get; set; }

        [Display(Name = "نام کالا")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "توضیحات کوتاه")]
        [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ShortText { get; set; }

        [Display(Name = "تصویر")]
        public string Image { get; set; }


        [Display(Name = "برند")]
        public int BrandId { get; set; }


        #region Navigation Property


        [Display(Name = "گروه ")]
        [ForeignKey(nameof(ProductGroupId))]
        public virtual ProductGroup ProductGroup { get; set; }

        [Display(Name = "برند")]
        [ForeignKey(nameof(BrandId))]
        public virtual Brand Brand { get; set; }


        public ICollection<Reception> Receptions { get; set; }

        #endregion
    }
}
