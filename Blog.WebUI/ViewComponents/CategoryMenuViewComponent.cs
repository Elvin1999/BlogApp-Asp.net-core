using Blog.WebUI.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.ViewComponents
{
    public class CategoryMenuViewComponent:ViewComponent
    {
        private ICategoryRepository _repo;

        public CategoryMenuViewComponent(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public IViewComponentResult Invoke()
        {
            return View(_repo.GetAll());
        }
    }
}
