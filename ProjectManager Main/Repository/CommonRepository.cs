
using Microsoft.AspNetCore.Authentication;
using Microsoft.CodeAnalysis;
using ProjectManager_Main.SQLConnection;
using ProjectManager_Main.ViewModels.Admin;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;


namespace ProjectManager_Main.Repository
{
    public class CommonRepository
    {
        private readonly Context context = new Context();
        //tova se pishe tuk, a ne otdelno navsqkude, zashtoto se suzdavat nqkolko razlichno cnnectiona na vednuj i data bazata pravi bum :D.
        public async Task DeleteUser(Guid id)
        {
            //tuk imashe method

            //tuk imashe method
            Entity.User user = await context.Users.FindAsync(id);

            context.Users.Remove(user);
            List<Entity.Project> projects = context.Projects.Where(x => x.OwnerId == id).ToList<Entity.Project>();

            foreach (var item in projects)
            {
                await DeleteProject(item.Id);
            }
            
            await context.SaveChangesAsync();
        }
        public async Task<bool> DeleteProject(Guid id)
        {
            //tuk imashe method

            Entity.Project project = context.Projects.Find(id);
            if (project.OwnerId != Tools.AuthenticationService.LoggedUser.Id)
            {
                return true;
            }

            context.Projects.Remove(project);
            List<Entity.Task> tasks = context.Tasks.Where(x => x.ProjectId == project.Id).ToList<Entity.Task>();
            foreach (var task in tasks)
            {
                await DeleteTask(task.Id);
            }


            await context.SaveChangesAsync();
            return false;

        }
        public async Task DeleteTask(Guid id)
        {
           
            context.Tasks.Remove(context.Tasks.Find(id));

            await context.SaveChangesAsync();
        }

    }
}
