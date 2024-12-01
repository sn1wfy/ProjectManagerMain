using System.ComponentModel.DataAnnotations;

namespace ProjectManager_Main.Entity
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }

        public Guid OwnerId { get; set; }

        public Guid TaskId { get; set; }

        public string Name { get; set; }
        public string Body { get; set; }



        public Comment()
        {
            Id = Guid.NewGuid();

        }
        public Comment(Guid ownerId, Guid taskId, string body)
        {
            Id = Guid.NewGuid();
            OwnerId = ownerId;
            TaskId = taskId;
            Body = body;
        }
    }

}
