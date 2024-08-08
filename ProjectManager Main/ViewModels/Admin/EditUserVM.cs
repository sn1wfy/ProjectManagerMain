
using System.ComponentModel.DataAnnotations;

namespace ProjectManager_Main.ViewModels.Admin
{
    public class EditUserVM : UserDetailsVM
    {
        public EditUserVM()
        {

        }
        public EditUserVM(ProjectManager_Main.Entity.User model)
        {
            Id = Guid.NewGuid();
            Username = model.Username;
            
            FirstName = model.FirstName;
            LastName = model.LastName;
            Email = model.Email;
            IsAdmin = model.IsAdmin;
        }



    }
}
