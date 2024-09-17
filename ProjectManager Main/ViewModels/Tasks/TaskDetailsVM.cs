using System.ComponentModel.DataAnnotations;

namespace ProjectManager_Main.ViewModels.Tasks
{
    public class TaskDetailsVM
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }

        [Display(Name = "Author: ")]
        public string Author { get; set; }

        [Display(Name = "Name: ")]
        public string Name { get; set; }

        [Display(Name = "Description: ")]
        public string Description { get; set; }

        [Display(Name = "State")]
        public bool State {  get; set; }

        //public List<Entity.Task> Tasks { get; set; }
    }
}
