using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Entities.Common;

namespace Model.Entities
{
    public class Sms : BaseEntityNotId
    {
        [Key]
        public int SmsId { get; set; }

        public int  ReceptionId { get; set; }

        public string Description { get; set; }

        public string SmsStatus { get; set; }

        #region Relation

        //[ForeignKey(nameof(ReceptionId))]
        //public DbSet<Reception> Receptions { get; set; }

        #endregion

    }

}
