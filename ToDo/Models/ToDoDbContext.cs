using System.Data.Entity;

namespace ToDo.Models
{
    class ToDoDbContext : DbContext
    {
        public ToDoDbContext() : base("ToDoDb")
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Task> Tasks { get; set; }  
    }
}
