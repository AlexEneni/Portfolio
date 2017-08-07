using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class GaleryPostModels
    {
        [Key]
        public int ID { get; set; }
        [StringLength(55, ErrorMessage = ("To nie miejsce na referat! (55znakow)"))]
        [DataType(DataType.MultilineText)]
        public string title { get; set; }
        public string imageUrl { get; set; }
        public string descUrl { get; set; }
        public DateTime date { get; set; }
    }
}