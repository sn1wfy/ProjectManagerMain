using System.ComponentModel.DataAnnotations;

namespace ProjectManager_Main.ViewModels.ProjectsVM
{
    public class ProjectDetailsVM
    {
        public Guid Id { get; set; }

        [Display(Name = "Author: ")]
        public string Author { get; set; }

        [Display(Name = "Name: ")]
        public string Name { get; set; }

        [Display(Name = "Description: ")]
        public string Description { get; set; }
    }
}
