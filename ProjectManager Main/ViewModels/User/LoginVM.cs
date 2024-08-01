using System.ComponentModel.DataAnnotations;

namespace ProjectManager_Main.ViewModels.User
{
    public class LoginVM
    {
        [Display(Name = "UserName: ")]
        [Required(ErrorMessage = "This field is required!")]
        public string Username { get; set; }

        [Display(Name = "Password: ")]
        [Required(ErrorMessage = "This field is required!")]
        public string Password { get; set; }
    }
}
