using Microsoft.AspNetCore.Mvc;
using ProjectManager_Main.Entity;
using ProjectManager_Main.SQLConnection;
using ProjectManager_Main.Tools;
using ProjectManager_Main.ViewModels.ProjectsVM;
using System.Xml.Linq;
namespace ProjectManager_Main.Controllers
{
    public class ProjectController : Controller
    {
        private readonly Context context;
        public ProjectController()
        {
            
            context = new Context();
        }
        public IActionResult Index()
        {
            if (AuthenticationService.LoggedUser == null)
            {
                return RedirectToAction("Index", "Home");
            }

   

            return View(context.Projects.Where(x=>x.OwnerId == AuthenticationService.LoggedUser.Id).AsEnumerable());


        }
        [HttpGet]
        public IActionResult Create()
        {
            if (AuthenticationService.LoggedUser == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new CreateProjectVM());
        }
        [HttpPost]

        public IActionResult Create(CreateProjectVM model)
        {
            if (AuthenticationService.LoggedUser == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            Project project = new Project();
            project.Id = Guid.NewGuid();
            project.OwnerId = AuthenticationService.LoggedUser.Id;
            project.Name = model.Name;
            project.Description = model.Description;

            context.Projects.Add(project);
            context.SaveChanges();
            return RedirectToAction("Index", "Project");

            
        }

        [HttpGet]
        public IActionResult Delete(Guid Id)
        {
            if (AuthenticationService.LoggedUser == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Project project = context.Projects.Find(Id);
            if(project.OwnerId != AuthenticationService.LoggedUser.Id)
            {
                return RedirectToAction("Index", "Project");
            }
            ProjectDetailsVM projectDetailsVM = new ProjectDetailsVM();
            projectDetailsVM.Id = Id;
            projectDetailsVM.Name = project.Name;
            projectDetailsVM.Description = project.Description;

            return View(projectDetailsVM);
        }
        [HttpPost]
        public IActionResult DeleteProject(Guid Id)
        {
            if (AuthenticationService.LoggedUser == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Project project = context.Projects.Find(Id);
            if (project.OwnerId != AuthenticationService.LoggedUser.Id)
            {
                return RedirectToAction("Index", "Project");
            }
            context.Projects.Remove(project);
            context.SaveChanges();

            return RedirectToAction("Index", "Project"); 
        }


        [HttpGet]
        public IActionResult Details(Guid id)
        {
            if (AuthenticationService.LoggedUser == null)
            {
                return RedirectToAction("Index", "Home");
            }
            

            var project = context.Projects.FirstOrDefault(x => x.Id == id);
            if (project == null)
            {
                return RedirectToAction("Index");
            }
            var model = new ProjectDetailsVM()
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                Author = context.Users.Find(project.OwnerId).Username
            };
            return View(model);

        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            if (AuthenticationService.LoggedUser == null)
            {
                return RedirectToAction("Index", "Home");
            }


            var project = context.Projects.FirstOrDefault(x => x.Id == id);
            if (project == null)
            {
                return RedirectToAction("Index");
            }
            var model = new ProjectDetailsVM()
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                
            };
            return View(model);
            

        }
        [HttpPost]
        public IActionResult Edit(EditProjectVM model)
        {
            if (AuthenticationService.LoggedUser == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var project = context.Projects.FirstOrDefault(x=>x.Id == model.Id);

            if(project == null)
            {
                return RedirectToAction("Index");
            }
            project.Name = model.Name;
            project.Description = model.Description;
            context.SaveChanges();
            return RedirectToAction("Index", "Project");
        }



    }
}
