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
    public class RequestDevice : BaseEntityNotId
    {
        [Key]
        public int RequestDeviceId { get; set; }
        [Display(Name = "کاربر")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserId { get; set; }
        [Display(Name = "مشتری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string CustomerId { get; set; }

        [Display(Name = "محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ProductId { get; set; }

        [Display(Name = "شرح")]
        public string Description { get; set; }

        [Display(Name = "تکمیل شده؟")]
        public bool ViewStatus { get; set; }

        #region Relation

        [Display(Name = "محصول")]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [Display(Name = "مشتری")]
        [ForeignKey(nameof(CustomerId))]
        public ApplicationUser User { get; set; }


        #endregion



    }
}
