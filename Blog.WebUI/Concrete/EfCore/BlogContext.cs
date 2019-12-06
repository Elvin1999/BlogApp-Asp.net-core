using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.WebUI.Entities;
namespace Blog.WebUI.Concrete.EfCore
{
    public class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options):base(options)
        {

        }
        public DbSet<Blog.WebUI.Entities.Blog> Blogs { get; set; }
        public DbSet<Blog.WebUI.Entities.Category> Categories { get; set; }
        
    }
}
