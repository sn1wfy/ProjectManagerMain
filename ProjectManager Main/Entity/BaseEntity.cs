using System.ComponentModel.DataAnnotations;

namespace ProjectManager_Main.Entity
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
