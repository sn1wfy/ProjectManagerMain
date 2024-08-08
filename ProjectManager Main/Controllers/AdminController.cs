using Microsoft.AspNetCore.Mvc;
using ProjectManager_Main.Entity;
using ProjectManager_Main.SQLConnection;
using ProjectManager_Main.ViewModels.User;
using ProjectManager_Main.Tools;
using ProjectManager_Main.ViewModels.ProjectsVM;
using ProjectManager_Main.ViewModels.Admin;
using Microsoft.CodeAnalysis;

namespace ProjectManager_Main.Controllers
{
    public class AdminController : Controller
    {
        private readonly Context context;
        public AdminController()
        {

            context = new Context();
        }
        public IActionResult Index()
        {
            if (AuthenticationService.LoggedUser == null || !AuthenticationService.LoggedUser.IsAdmin)
            {
                return RedirectToAction("Index", "Home");
            }



            return View(context.Users.AsEnumerable());


        }
        [HttpGet]
        public IActionResult Create()
        {
            if (AuthenticationService.LoggedUser == null || !AuthenticationService.LoggedUser.IsAdmin)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new CreateUserVM());
        }
        [HttpPost]

        public IActionResult Create(CreateUserVM model)
        {
            if (AuthenticationService.LoggedUser == null || !AuthenticationService.LoggedUser.IsAdmin)
            {
                return RedirectToAction("Index", "Home");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User user = new User(model);
            
            


            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction("Index", "Admin");


        }

        [HttpGet]
        public IActionResult Delete(Guid Id)
        {
            if (AuthenticationService.LoggedUser == null || !AuthenticationService.LoggedUser.IsAdmin)
            {
                return RedirectToAction("Index", "Home");
            }
            User user = context.Users.Find(Id);
            UserDetailsVM userDetailsVM = new UserDetailsVM(user);
            

            return View(userDetailsVM);
        }
        [HttpPost]
        public IActionResult DeleteUser(Guid Id)
        {
            if (AuthenticationService.LoggedUser == null || !AuthenticationService.LoggedUser.IsAdmin)
            {
                return RedirectToAction("Index", "Home");
            }
            if (Id == AuthenticationService.LoggedUser.Id)
            {
                return RedirectToAction("Index", "Admin");
            }
            User user = context.Users.Find(Id);
           
            context.Users.Remove(user);
            //context.Projects.Remove(user);
            //---------^^ TOVA SE SMENQ-------//
            context.SaveChanges();

            return RedirectToAction("Index", "Admin");
            //----------------------------------^^ TOVA SE SMENQ SUSHTO-------//
        }


        [HttpGet]
        public IActionResult Details(Guid id)
        {
            if (AuthenticationService.LoggedUser == null || !AuthenticationService.LoggedUser.IsAdmin)
            {
                return RedirectToAction("Index", "Home");
            }


            var user = context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            UserDetailsVM UserDetailsVM = new UserDetailsVM(user);
            
            return View(UserDetailsVM);

        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            if (AuthenticationService.LoggedUser == null || !AuthenticationService.LoggedUser.IsAdmin)
            {
                return RedirectToAction("Index", "Home");
            }


            var user = context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            EditUserVM editUserVM = new EditUserVM(user);
            return View(editUserVM);


        }
        [HttpPost]
        public IActionResult Edit(EditUserVM model)
        {
            if (AuthenticationService.LoggedUser == null || !AuthenticationService.LoggedUser.IsAdmin)
            {
                return RedirectToAction("Index", "Home");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = context.Users.FirstOrDefault(x => x.Id == model.Id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            user.Username = model.Username;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.IsAdmin = model.IsAdmin;
           
            context.SaveChanges();
            return RedirectToAction("Index", "Admin");
          
            
        }
    }
}
