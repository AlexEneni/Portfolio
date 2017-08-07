using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Portfolio.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("DefaultConnection") { }

        public DbSet<SmModels> Sm { get; set; }
        public DbSet<ContactSMModels> Contact { get; set; }
        public DbSet<BlogPostModels> BlogPost { get; set; }
        public DbSet<GaleryPostModels> GaleryPost { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}