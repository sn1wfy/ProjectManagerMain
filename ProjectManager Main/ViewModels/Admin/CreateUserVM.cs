
using ProjectManager_Main.ViewModels.User;
using System.ComponentModel.DataAnnotations;
namespace ProjectManager_Main.ViewModels.Admin
{
    public class CreateUserVM : RegisterVM
    {
        [Display(Name = "IsAdmin: ")]
        
        public bool IsAdmin { get; set; }

    }
}
