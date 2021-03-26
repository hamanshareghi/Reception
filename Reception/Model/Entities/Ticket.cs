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
    public class Ticket : BaseEntityNotId
    {
        [Key]
        public int TicketId { get; set; }
        
        [Display(Name = "کاربر")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserId { get; set; }
        
        [Display(Name = "گیرنده")]
        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Reciver { get; set; }
        
        [Display(Name = "عنوان")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Subject { get; set; }
        
        [Display(Name = "شرح")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        [Display(Name = "وضعیت")]
        public MessageStatus MessageStatus { get; set; }

        #region Relation

        [Display(Name = "مسئول")]
        [ForeignKey(nameof(Reciver))]
        public ApplicationUser User { get; set; }

        #endregion

    }
    public enum MessageStatus
    {
        Seen = 1,
        Unread =2
    }
}
