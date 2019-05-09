using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HackerNews.Api;
using Microsoft.AspNetCore.Mvc;
using HackerNews.Web.Models;

namespace HackerNews.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var api = new HackerNewsApi();
            return View(api.GetTopStories());
        }
    }
}
