using ProjectManager_Main.Entity;
using ProjectManager_Main.SQLConnection;
using ProjectManager_Main.ViewModels.User;

namespace ProjectManager_Main.Tools
{
    public class AuthenticationService
    {
        public static User? LoggedUser { get; private set; }

        public static void Authenticate(LoginVM item)
        {
            using (var Context = new Context())
            {
                LoggedUser = Context.Users.Where(x => 
                                                     x.Username == item.Username && 
                                                      x.Password == item.Password)
                                                      .FirstOrDefault();
                
            }
           

        }
        public static void Logout()
        {
            LoggedUser = null;
        }
    }
}
