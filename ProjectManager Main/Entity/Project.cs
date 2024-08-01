using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager_Main.Entity
{
    [Table("Projects")]
    public class Project : BaseEntity
    {
        public Guid OwnerId { get; set; }
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
