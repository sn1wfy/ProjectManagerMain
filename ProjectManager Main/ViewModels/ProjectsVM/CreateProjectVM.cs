using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager_Main.ViewModels.ProjectsVM
{
    
    public class CreateProjectVM
    {
        [Display(Name = "Name: ")]
        [Required(ErrorMessage = "This field is required!")]
        public string Name { get; set; }

        [Display(Name = "Description: ")]
        [Required(ErrorMessage = "This field is required!")]
        public string Description { get; set; }
    }
}
