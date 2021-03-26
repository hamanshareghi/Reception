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
    public class DeviceImage : BaseEntityNotId
    {
        [Key]
        public int DeviceImageId { get; set; }

        [Display(Name = "پذیرش")]
        public int ReceptionId { get; set; }

        [Display(Name = "تصویر")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Image { get; set; }

        #region Relation
        [Display(Name = "پذیرش")]
        [ForeignKey(nameof(ReceptionId))]
        public Reception Reception { get; set; }

        #endregion
    }
}
