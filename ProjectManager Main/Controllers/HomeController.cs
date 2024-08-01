using Microsoft.AspNetCore.Mvc;
using ProjectManager_Main.Entity;
using ProjectManager_Main.SQLConnection;
using ProjectManager_Main.Tools;
using ProjectManager_Main.ViewModels.User;
using System.Diagnostics;

namespace ProjectManager_Main.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context context;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            context = new Context();
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterVM());
        }
        [HttpPost]
        public IActionResult Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User item = new User(model);
            context.Users.Add(item);
            context.SaveChanges();

            return RedirectToAction("Login");

        }


        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginVM());
        }
        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            AuthenticationService.Authenticate(model);
            return RedirectToAction("Index");

        }

        public IActionResult Logout()
        {
            AuthenticationService.Logout();
            return RedirectToAction("Index");
        }

    }
}