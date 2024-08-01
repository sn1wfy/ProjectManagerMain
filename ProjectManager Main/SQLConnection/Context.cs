using ProjectManager_Main.Entity;
using System.Data.Entity;

namespace ProjectManager_Main.SQLConnection
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }

        public Context() : base("Server = localhost\\sqlexpress; Database=ProjectManagerMain;Trusted_Connection=True;")
        {
            Users = this.Set<User>();
            Projects = this.Set<Project>();
        }
    }
}
