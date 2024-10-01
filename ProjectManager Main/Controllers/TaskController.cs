using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using ProjectManager_Main.Entity;
using ProjectManager_Main.Repository;
using ProjectManager_Main.SQLConnection;
using ProjectManager_Main.Tools;
using ProjectManager_Main.ViewModels.ProjectsVM;
using ProjectManager_Main.ViewModels.Tasks;
using System.Xml.Linq;

namespace ProjectManager_Main.Controllers
{
    public class TaskController : Controller
    {
        private readonly Context context;
        public TaskController()
        {

            context = new Context();
        }
        [HttpGet]
        public IActionResult Create(Guid id)
        {
            if (AuthenticationService.LoggedUser == null || id == Guid.Empty || context.Projects.Find(id).OwnerId!=AuthenticationService.LoggedUser.Id)
            {
                return RedirectToAction("Index", "Home");
            }
            CreateTaskVM model = new CreateTaskVM();
            model.ProjectId = id;

            return View(model);
        }
        [HttpPost]

        public IActionResult Create(CreateTaskVM model)
        {
            if (AuthenticationService.LoggedUser == null || model.ProjectId == Guid.Empty || context.Projects.Find(model.ProjectId).OwnerId != AuthenticationService.LoggedUser.Id)
            {
                return RedirectToAction("Index", "Home");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Entity.Task task = new Entity.Task();
            task.Id = Guid.NewGuid();
            task.ProjectId = model.ProjectId;
            task.Name = model.Name;
            task.Description = model.Description;
            task.State = model.State;

            context.Tasks.Add(task);
            context.SaveChanges();
            return RedirectToAction("Details", "Project", new {id = task.ProjectId});


        }
        //delete
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            EditTaskVM model = new EditTaskVM(context.Tasks.Find(id));
            return View(model);
            
        }
        [HttpPost]
        public IActionResult Edit(EditTaskVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Entity.Task task = context.Tasks.Find(model.Id);
            task.State = model.State;
            task.Description = model.Description;
            task.Name = model.Name;
            context.SaveChanges();
            return RedirectToAction("Details", "Project", new { id = task.ProjectId });
        }
        public IActionResult Delete(Guid id)
        {
            Entity.Task task = context.Tasks.Find(id);
            TaskDetailsVM model = new TaskDetailsVM();

            model.Id = task.Id;
            model.Name = task.Name;
            model.Description = task.Description;
            model.State = model.State;
            model.ProjectId = task.ProjectId;
            model.Author = context.Users.Find(context.Projects.Find(task.ProjectId).OwnerId).Username;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteTask(Guid Id)
        {
            
            CommonRepository commonRepository = new CommonRepository();
            
            await commonRepository.DeleteTask(Id);

            return RedirectToAction("Details", "Project", new {id = context.Tasks.Find(Id).ProjectId});
        }
        public IActionResult Details(Guid id)
        {
            Entity.Task task = context.Tasks.Find(id);
            TaskDetailsVM model = new TaskDetailsVM();

            model.Id = task.Id;
            model.Name = task.Name;
            model.Description = task.Description;
            model.State = model.State;
            model.ProjectId = task.ProjectId;
            model.Author = context.Users.Find(context.Projects.Find(task.ProjectId).OwnerId).Username;
            return View(model);
        }
       

    }
}
