using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Portfolio.Models
{
    public class ContactModels
    {
        
        [Display(Name = "Imię:")]
        [Required(ErrorMessage = "Pole wymagane")]
        [StringLength(30,ErrorMessage = ("Twoje imie jest za długie! (30znakow)"))]
        public string name { get; set; }

        [Display(Name = "Twój e-mail:")]
        [Required(ErrorMessage = "Pole wymagane")]
        [EmailAddress]
        public string email { get; set; }

        [Display(Name = "Nr telefonyu:")]
        [Phone]
        [RegularExpression(@"([\+]){0,1}([0-9]{2})?[\-\s]?[-]?([0-9]{3})?[-\s]?([0-9]{3})[-\s]?([0-9]{3})$",
            ErrorMessage = "Numer w formacie 666***111")]
        public string tel { get; set; }

        [Display(Name = "Co chesz nam przekazać?")]
        [Required(ErrorMessage = "Pole wymagane")]
        [StringLength(255, ErrorMessage = ("To nie miejsce na referat! (255znakow)"))]
        [DataType(DataType.MultilineText)]
        public string text { get; set; }
    }
}