using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager_Main.Entity
{
    [Table("Tasks")]
    public class Task
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool State { get; set; }
    }
}
