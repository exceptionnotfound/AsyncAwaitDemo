using AsyncAwaitDemo.Lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AsyncAwaitDemo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            ContentManagement service = new ContentManagement();
            var content = service.GetContent();
            var count = service.GetCount();
            var name = service.GetName();

            watch.Stop();
            ViewBag.WatchMilliseconds = watch.ElapsedMilliseconds;
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> IndexAsync()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            ContentManagement service = new ContentManagement();
            var contentTask = service.GetContentAsync();
            var countTask = service.GetCountAsync();
            var nameTask = service.GetNameAsync();

            var content = await contentTask;
            var count = await countTask;
            var name = await nameTask;
            watch.Stop();
            ViewBag.WatchMilliseconds = watch.ElapsedMilliseconds;
            return View("Index");
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}