using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities.Common;

namespace Model.Entities
{
    public class Defect : BaseEntityNotId
    {
        [Key]
        public int DefectId { get; set; }

        [Display(Name = "ایراد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Name { get; set; }

        [Display(Name = "شرح")]
        public string Description { get; set; }

        #region Relation

        public ICollection<DeviceDefect> DeviceDefects { get; set; }

        #endregion
    }
}
