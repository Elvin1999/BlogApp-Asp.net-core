using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.Concrete.EfCore
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            BlogContext context = app.ApplicationServices.GetRequiredService<BlogContext>();

            context.Database.Migrate();
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Entities.Category() { Name = "Category 1" },
                    new Entities.Category() { Name = "Category 2" },
                    new Entities.Category() { Name = "Category 3" },
                    new Entities.Category() { Name = "Category 4" }
                    );
                context.SaveChanges();
            }
            if (!context.Blogs.Any())
            {
                context.Blogs.AddRange(
                    new Entities.Blog()
                    {
                           Body="Blog Body 1", CategoryId=1, Date=DateTime.Now.AddDays(-1),
                        Description="Blog Description 1", Image="1.jpg",
                        IsApproved=true, Title="Blog Title 1"
                    },
                    new Entities.Blog()
                    {
                        Body = "Blog Body 1",
                        CategoryId = 2,
                        Date = DateTime.Now.AddDays(-2),
                        Description = "Blog Description 2",
                        Image = "2.jpg",
                        IsApproved = true,
                        Title = "Blog Title 2"
                    }
                    , new Entities.Blog()
                    {
                        Body = "Blog Body 3",
                        CategoryId = 3,
                        Date = DateTime.Now.AddDays(-3),
                        Description = "Blog Description 3",
                        Image = "3.jpg",
                        IsApproved = false,
                        Title = "Blog Title 3"
                    },
                     new Entities.Blog()
                     {
                         Body = "Blog Body 4",
                         CategoryId = 4,
                         Date = DateTime.Now.AddDays(-4),
                         Description = "Blog Description 4",
                         Image = "4.jpg",
                         IsApproved = true,
                         Title = "Blog Title 4"
                     }
                    );
                context.SaveChanges();
            }

        }
    }
}
