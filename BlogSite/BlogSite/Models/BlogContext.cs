using BlogSite.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogSite.Models
{
    public class BlogContext: IdentityDbContext<ApplicationUser>
    {
        public BlogContext() : base("blogdb")
        {

            Database.SetInitializer(new BlogInitializer());
            
        }
        public DbSet<Blog> Bloglar { get; set; }
        public DbSet<Category> Kategoriler { get; set; }
        public DbSet<Projeler> Projeler { get; set; }

    }
}