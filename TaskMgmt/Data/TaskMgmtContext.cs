using Microsoft.EntityFrameworkCore;

namespace TaskMgmt.Data
{
    public class TaskMgmtContext : DbContext
    {
        public TaskMgmtContext(DbContextOptions<TaskMgmtContext> options) : base(options)
        {
        }
    
        public DbSet<TaskItem> Tasks { get; set; }

    }
}
