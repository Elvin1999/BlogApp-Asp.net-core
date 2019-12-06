using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Concrete.EfCore
{
   public class BlogContext:DbContext
    {
        public DbSet<Blog> MyProperty { get; set; }
    }
}
