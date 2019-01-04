using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Explore_California.Models;
using Microsoft.AspNetCore.Mvc;

namespace Explore_California.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            var posts = new[]
            {
                new Post {
                    Title = "My First Post",
                    Author = "Saney Alam",
                    Posted = DateTime.Now,
                    Body = "This is a great blog post, don't you think?"
                },
                new Post
                {
                    Title = "My Second Post",
                    Author = "Jannatul Ferdous",
                    Posted = DateTime.Now,
                    Body = "This is a great blog post, don't you think?"
                },
                new Post
                {
                    Title = "My Third Post",
                    Author = "Habibur Rahman",
                    Posted = DateTime.Now,
                    Body = "This is a great blog post, don't you think?"
                }
            };

            return View(posts);
        }

        [Route("{year:min(2010)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, string key) {

            var post = new Post {
                Title = "My Blog Post",
                Author="Saney Alam",
                Posted = DateTime.Now,
                Body ="This is a great blog post, don't you think?"
            }; 
            return View(post);
        }
    }
}