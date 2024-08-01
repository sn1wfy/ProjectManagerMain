using ProjectManager_Main.ViewModels.User;

namespace ProjectManager_Main.Entity
{
    public class User : BaseEntity
    {

        
        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }
        public User()
        {

        }
        public User(RegisterVM model)
        {
            Id = Guid.NewGuid();
            Username = model.Username;
            Password = model.Password;
            FirstName = model.FirstName;
            LastName = model.LastName;
            Email = model.Email;
            IsAdmin = false;
        }
    }

}
    
