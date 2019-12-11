using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.Abstraction
{
   public interface IBlogRepository
    {
        IQueryable<Entities.Blog> GetAll();
        Entities.Blog GetById(int id);
        void AddBlog(Entities.Blog blog);
        void UpdateBlog(Entities.Blog blog);
        void DeleteBlog(int id);
    }
}
