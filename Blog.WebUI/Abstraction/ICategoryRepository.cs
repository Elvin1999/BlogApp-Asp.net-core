using Blog.WebUI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.Abstraction
{
   public interface ICategoryRepository
    {
        IQueryable<Category> GetAll();
        Category GetById(int id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
