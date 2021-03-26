using System.ComponentModel.DataAnnotations;
using Model.Entities.Common;

namespace Model.Entities
{
    public class Carousel : BaseEntity<int>
    {

        [Display(Name = "عنوان")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Caption { get; set; }

        [Display(Name = "تصویر")]
        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ImageName { get; set; }

        [Display(Name = "لینک")]
        public string LinkPage { get; set; }

    }
}
