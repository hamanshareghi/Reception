using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities.Common;

namespace Model.Entities
{
    public class Rule : BaseEntity<int>
    {
        [Display(Name = "فروش")]
        public string Sale { get; set; }

        [Display(Name = "ارسال")]
        public string Send { get; set; }
        
        [Display(Name = "استفاده")]
        public string Use { get; set; }
 
        [Display(Name = "پرداخت")]
        public string Payment { get; set; }
        
        [Display(Name = "حرییم خصوصی")]
        public string Privacy { get; set; }

    }
}
