using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities.Common;

namespace Model.Entities
{
    public class Status : BaseEntityNotId
    {
        [Key]
        public int StatusId { get; set; }
        [Display(Name = "نام")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name { get; set; }

        #region Relation

        public ICollection<Duty> Duties { get; set; }

        #endregion

    }
}
