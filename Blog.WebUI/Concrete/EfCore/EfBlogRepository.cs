using Blog.WebUI.Abstraction;
using Blog.WebUI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.Concrete.EfCore
{
    public class EfBlogRepository : IBlogRepository
    {
        private BlogContext context;

        public EfBlogRepository(BlogContext context)
        {
            this.context = context;
        }

        public void AddBlog(Entities.Blog blog)
        {
            context.Blogs.Add(blog);
            context.SaveChanges();
        }

        public void DeleteBlog(int id)
        {
            var blog = context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (blog != null)
            {
                context.Blogs.Remove(blog);
                context.SaveChanges();
            }
        }

        public IQueryable<Entities.Blog> GetAll()
        {
            return context.Blogs;
        }

        public Entities.Blog GetById(int id)
        {
            return context.Blogs.FirstOrDefault(x => x.BlogId == id);
        }

        public void UpdateBlog(Entities.Blog blog)
        {
            context.Entry(blog).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
