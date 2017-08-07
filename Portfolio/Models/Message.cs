using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class Message
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Name:")]
        [Required(ErrorMessage = "is Requred!")]
        [StringLength(30, ErrorMessage = ("Your name is too long! (30chars)"))]
        public String userName { get; set; }

        [Display(Name = "Name:")]
        [Required(ErrorMessage = "is Requred!")]
        [StringLength(30, ErrorMessage = ("It is too long! (30chars)"))]
        public string title { get; set; }

        [Display(Name = "Message:")]
        [Required(ErrorMessage = "is Requred!")]
        [StringLength(255, ErrorMessage = ("It is too long! (255znakow)"))]
        [DataType(DataType.MultilineText)]
        public String text { get; set; }

        [Display(Name = "Your eMail:")]
        [Required(ErrorMessage = "is Requred!")]
        [EmailAddress(ErrorMessage = "This is not e-mail adres")]
        public string eMail { get; set; }

        public DateTime dateOfSend { get; set; }
        public bool wasDisplayed { get; set; }
    }
}