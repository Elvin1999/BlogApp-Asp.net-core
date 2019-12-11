using Blog.WebUI.Abstraction;
using Blog.WebUI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.Concrete.EfCore
{
    public class EfCategoryRepository : ICategoryRepository
    {
        private BlogContext context;

        public EfCategoryRepository(BlogContext context)
        {
            this.context = context;
        }

        public void AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category != null)
            {
            context.Categories.Remove(category);
                context.SaveChanges();
            }

        }

        public IQueryable<Category> GetAll()
        {
            return context.Categories;
        }

        public Category GetById(int id)
        {
            return context.Categories.FirstOrDefault(x => x.CategoryId == id);
        }

        public void UpdateCategory(Category category)
        {
            context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
