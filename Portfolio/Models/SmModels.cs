using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class SmModels
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public bool active { get; set; }
        public bool onHomePage { get; set; }
        public string symbol { get; set; }
        public string url { get; set; }
    }

    public class ContactSMModels
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool active { get; set; }
        public string symbol { get; set; }
        public string value { get; set; }
    }
}