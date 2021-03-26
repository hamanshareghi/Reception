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
    public class DeviceDefect : BaseEntityNotId
    {
        [Key]
        public int DeviceDefectId { get; set; }

        [Display(Name = "پذیرش")]
        public int ReceptionId { get; set; }

        [Display(Name = "ایراد")]
        public int DefectId { get; set; }


        #region Relation

        [Display(Name = "پذیرش")]
        [ForeignKey(nameof(ReceptionId))]
        public Reception Reception { get; set; }

        [Display(Name = "ایراد")]
        [ForeignKey(nameof(DefectId))]
        public Defect Defect { get; set; }

        #endregion
    }
}
