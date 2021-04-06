using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities.Common;

namespace Model.Entities
{
     public class Warranty : BaseEntityNotId
    {
        [Key]
        public int WarrantyId { get; set; }

        public int ProductId { get; set; }
    }
}
