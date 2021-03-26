using System.ComponentModel.DataAnnotations;
using Model.Entities.Common;

namespace Model.Entities
{
    public class OneData : BaseEntity<int>
    {

        [Display(Name = "معرفی")]
        public string Introduction { get; set; }


        [Display(Name = "قوانین سایت")]
        public string SiteRules { get; set; }


        [Display(Name = "حریم خصوصی")]
        public string Privacy { get; set; }

        [Display(Name = "آدرس سایت")]
        public string SiteAddress { get; set; }

    }
}
