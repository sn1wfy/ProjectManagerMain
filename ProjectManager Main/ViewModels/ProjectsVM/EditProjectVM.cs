using System.ComponentModel.DataAnnotations;

namespace ProjectManager_Main.ViewModels.ProjectsVM
{
    public class EditProjectVM
    {
        public Guid Id { get; set; }

        [Display(Name = "Name: ")]
        [Required(ErrorMessage = "This field is required!")]
        public string Name { get; set; }
       
        [Required(ErrorMessage = "This field is required!")]
        public string Description { get; set; }
    }
}
