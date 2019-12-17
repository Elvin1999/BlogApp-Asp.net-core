using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.WebUI.Abstraction;
using Blog.WebUI.Models;
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
            HomeBlogModel model = new HomeBlogModel();
            model.HomeBlogs = blogRepository.GetAll().Where(i => i.IsApproved == true && i.IsHome == true).ToList();
            model.SliderBlogs = blogRepository.GetAll().Where(i => i.IsApproved == true && i.IsSlider == true).ToList();
            return View(model);
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