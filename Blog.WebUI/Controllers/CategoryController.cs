using Blog.WebUI.Abstraction;
using Blog.WebUI.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.Controllers
{
    public class CategoryController:Controller
    {
        private ICategoryRepository repository;

        public CategoryController(ICategoryRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return View(repository.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                repository.AddCategory(category);
                return RedirectToAction("List");
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(repository.GetById(id));
        }
        [HttpPost]
        public IActionResult Details(Category category)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateCategory(category);
                TempData["message"] = $" {category.Name} was updated . . . ";
                return RedirectToAction("List");
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(repository.GetById(id));
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            repository.DeleteCategory(id);
            return RedirectToAction("List");
        }
    }
}
