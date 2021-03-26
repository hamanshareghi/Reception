using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;
using Model.Entities.Common;

namespace Model.Entities
{
    public class Brand : BaseEntityNotId
    {
        [Key]
        public int BrandId { get; set; }

        [Display(Name = "نام")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "تصویر")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Image { get; set; }

        [Display(Name = "لینک")]
        public string Link { get; set; }

        #region Relation
        [Display(Name = "برند")]
        public virtual ICollection<Product> Products { get; set; }

        #endregion
    }
}   
