using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.Models
{
    public class HomeBlogModel
    {
        public List<Entities.Blog> SliderBlogs { get; set; }
        public List<Entities.Blog> HomeBlogs { get; set; }
    }
}
