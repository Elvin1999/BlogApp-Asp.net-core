using Blog.WebUI.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Blog.WebUI.Controllers
{
    public class BlogController:Controller
    {
        private IBlogRepository _blogRepository;
        private ICategoryRepository _categoryRepository;
        public BlogController(IBlogRepository _blog,ICategoryRepository category)
        {
            _blogRepository = _blog;
            _categoryRepository = category;
        }
        public IActionResult Index(int? id)
        {
            var query = _blogRepository.GetAll().Where(i => i.IsApproved);
            if (id != null)
            {
                query = query.Where(i => i.CategoryId == id);
            }
            return View(query.OrderByDescending(i=>i.Date));
        }
        public IActionResult List()
        {
            return View(_blogRepository.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_categoryRepository.GetAll(),"CategoryId","Name");
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
        public IActionResult Details(Entities.Blog blog)
        {
            if (ModelState.IsValid)
            {
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
        [HttpPost,ActionName("Delete")]
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
