using System.ComponentModel.DataAnnotations;

namespace ProjectManager_Main.ViewModels.CommentsVM
{
    public class CreateVM
    {
        
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public Guid TaskId { get; set; }

        [Required]

        public string Body { get; set; }

    }
}
