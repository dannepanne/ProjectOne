using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectOne.Models;
using System.Diagnostics;

namespace ProjectOne.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProjectDBexaContext _context;
        public HomeController(ProjectDBexaContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [Route("")]
        [Route("index")]
        //[Route("~/")]
        public async Task<IActionResult> IndexAsync()
        {
            var projectDBexaContext = _context.ProjectTasks.Include(p => p.Project).Include(p => p.Resource);
            return View(await projectDBexaContext.ToListAsync());
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(string email, string id)
        {
            foreach (var item in _context.Resources)
            {
                if (email != null && id != null && email.Equals(item.Email) && id.Equals(item.Id.ToString()))
                {
                    HttpContext.Session.SetString("id", id);
                    HttpContext.Session.SetString("name", item.Firstname + " " + item.Lastname);
                    if(item.AdminRights != null)
                    {
                        HttpContext.Session.SetString("admin", item.AdminRights.ToString());
                    }
                    if (HttpContext.Session.GetString("admin") != null && HttpContext.Session.GetString("admin") == "Y")
                    {
                        return Redirect("~/Projects/Index");
                    }
                        return Redirect("~/ProjectTasks/Index");
                }

            }


            //ViewBag.error = "Invalid Account";
            return View("Index");


        }


        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("name");
            HttpContext.Session.Remove("id");
            if(HttpContext.Session.GetString("admin") != null)
            { HttpContext.Session.Remove("admin");}

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        internal List<Resource> GetResources()
        {
            List<Resource> reslist = _context.Resources.ToList();
            return reslist;
        }
        internal List<Project> GetProjects()
        {
            List<Project> projlist = _context.Projects.ToList();
            return projlist;
        }
        internal List<ProjectTask> GetTasks()
        {
            List<ProjectTask> taskslist = _context.ProjectTasks.ToList();
            return taskslist;
        }
    }
}