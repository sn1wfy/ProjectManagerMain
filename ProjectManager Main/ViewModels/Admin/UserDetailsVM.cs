using ProjectManager_Main.Entity;

namespace ProjectManager_Main.ViewModels.Admin
{
    public class UserDetailsVM : CreateUserVM
    {
        public Guid Id { get; set; }

        public UserDetailsVM()
        {

        }
        public UserDetailsVM(ProjectManager_Main.Entity.User model)
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
