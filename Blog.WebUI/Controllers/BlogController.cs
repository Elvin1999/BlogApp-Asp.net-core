using Blog.WebUI.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace Blog.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository _blogRepository;
        private ICategoryRepository _categoryRepository;
        public BlogController(IBlogRepository _blog, ICategoryRepository category)
        {
            _blogRepository = _blog;
            _categoryRepository = category;
        }
        public IActionResult Index(int? id, string q)
        {
            var query = _blogRepository.GetAll().Where(i => i.IsApproved);
            if (id != null)
            {
                query = query.Where(i => i.CategoryId == id);
            }
            if (!string.IsNullOrEmpty(q))
            {
                query = query.Where(i => i.Title.Contains(q) || i.Description.Contains(q) || i.Body.Contains(q));
            }
            return View(query.OrderByDescending(i => i.Date));
        }
        public IActionResult List()
        {
            return View(_blogRepository.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_categoryRepository.GetAll(), "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Entities.Blog blog)
        {
            blog.Date = DateTime.Now;
            blog.IsApproved = true;
            if (ModelState.IsValid)
            {
                _blogRepository.AddBlog(blog);
                return RedirectToAction("List");
            }
            return View(blog);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.Categories = new SelectList(_categoryRepository.GetAll(), "CategoryId", "Name");
            return View(_blogRepository.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Details(Entities.Blog blog, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", file.FileName);
                    using (var s = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(s);
                    }
                    blog.Image = file.FileName;
                }

                _blogRepository.UpdateBlog(blog);
                TempData["message"] = $" {blog.Title} was updated . . . ";
                return RedirectToAction("List");
            }
            return View(blog);
        }
        public IActionResult Delete(int id)
        {
            return View(_blogRepository.GetById(id));
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _blogRepository.DeleteBlog(id);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult ShowMore(int id)
        {

            return View(_blogRepository.GetById(id));
        }
    }
}
