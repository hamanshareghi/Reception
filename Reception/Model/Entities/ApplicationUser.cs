
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Model.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "نام کامل")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string FullName { get; set; }

        [Display(Name = "مشتری")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public Customer CustomerKind { get; set; }

        [Display(Name = "تماس")]
        [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Contact { get; set; }

        [Display(Name = "آدرس")]
        [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Address { get; set; }

        [Display(Name = "سمت")]
        [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Position { get; set; }

        [Display(Name = "شرح")]
        public string Description { get; set; }


        #region Relation

        public ICollection<Reception> Receptions { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<Leave> Leaves { get; set; }
        public ICollection<Debtor> Debtors { get; set; }
        public ICollection<RequestDevice> RequestDevices { get; set; }


        #endregion

    }



    public enum Customer
    {
        Customer = 1,
        Colleague = 2
    }

}
