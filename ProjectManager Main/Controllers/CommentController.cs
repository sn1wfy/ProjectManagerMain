using Microsoft.AspNetCore.Mvc;
using ProjectManager_Main.ViewModels.CommentsVM;
using ProjectManager_Main.Entity;
using ProjectManager_Main.Tools;
using ProjectManager_Main.SQLConnection;

namespace ProjectManager_Main.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Create(Guid Id)
        {
            CreateVM item = new CreateVM();
            item.TaskId = Id;
            return View(item);

        }
        [HttpPost]
        public IActionResult Create(CreateVM item)
        {
            if (!ModelState.IsValid)
            {

                return View(item);

            }
            Comment comment = new Comment(AuthenticationService.LoggedUser.Id, item.TaskId, item.Body);

            using (var context = new Context())
            {
                comment.Name = context.Users.Find(AuthenticationService.LoggedUser.Id).Username;
                context.Comments.Add(comment);
                context.SaveChanges();
                
            }
            return RedirectToAction("Details", "Task",new {id = item.TaskId});   


        }
    }
}
