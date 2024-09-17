using System.ComponentModel.DataAnnotations;

namespace ProjectManager_Main.ViewModels.Tasks
{
    public class EditTaskVM
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }

        [Display(Name = "Name: ")]
        [Required(ErrorMessage = "This field is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public string Description { get; set; }

        public bool State { get; set; }

        public EditTaskVM(Entity.Task task)
        {
            Id = task.Id;
            Name = task.Name;
            Description = task.Description;
            State = task.State;
            ProjectId = task.ProjectId;
        }
        public EditTaskVM() { 
        
        }
    }
}
