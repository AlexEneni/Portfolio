using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class BlogPostModels
    {
        [Key]
        public int ID { get; set; }
        public string author { get; set; }
        public DateTime date { get; set; }
        public string  Title { get; set; }
        public string textFileUrl { get; set; }
    }
}