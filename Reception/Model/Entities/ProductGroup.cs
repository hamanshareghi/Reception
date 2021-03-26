using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Entities;
using Model.Entities.Common;

namespace Model.Entities
{
    public class ProductGroup : BaseEntityNotId
    {

        [Key]
        public int ProductGroupId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string GroupName { get; set; }

        [DisplayName("گروه اصلی")]
        public int? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public virtual ProductGroup ParentGroup { get; set; }

        //[Display(Name = "تصویر")]
        //public string Image { get; set; }

        #region Relation

        //برای نمایش زیر دسته های هر گروه
        public virtual ICollection<ProductGroup> SubGroups { get; set; }

        [Display(Name = "گروه محصول")]

        public virtual ICollection<Product> Products { get; set; }



        #endregion


    }
}
