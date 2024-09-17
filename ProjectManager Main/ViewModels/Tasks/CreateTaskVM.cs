using System.ComponentModel.DataAnnotations;

namespace ProjectManager_Main.ViewModels.Tasks
{
    public class CreateTaskVM
    {
      
        public Guid ProjectId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; } 

        public bool State { get; set; }
    }
}
