using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.WebUI.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IBlogRepository blogRepository;

        public HomeController(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public IActionResult Index()
        {
            return View(blogRepository.GetAll());
        }
        public IActionResult Details()
        {

            return View();
        }
        public IActionResult List()
        {
            return View();
        }
    }
}