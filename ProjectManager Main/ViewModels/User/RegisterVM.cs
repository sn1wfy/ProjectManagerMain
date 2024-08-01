using System.ComponentModel.DataAnnotations;

namespace ProjectManager_Main.ViewModels.User
{
    public class RegisterVM 
    {
        [Display(Name = "UserName: ")]
        [Required(ErrorMessage = "This field is required!")]
        public string Username { get; set; }

        [Display(Name = "Password: ")]
        [Required(ErrorMessage = "This field is required!")]
        public string Password { get; set; }

        
        [Display(Name = "First Name: ")]
        [Required(ErrorMessage = "This field is required!")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name: ")]
        [Required(ErrorMessage = "This field is required!")]
        public string LastName { get; set; }


        [Display(Name = "Email: ")]
        [Required(ErrorMessage = "This field is required!")]
        public string Email { get; set; }


    }
}
