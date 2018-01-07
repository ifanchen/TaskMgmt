using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskMgmt.Data
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskMgmtContext ctx;

        public TaskRepository(TaskMgmtContext ctx)
        {
            this.ctx = ctx;            
        }

        public void AddTask(TaskItem newTask)
        {
            ctx.Add(newTask);
        }

        public IEnumerable<TaskItem> GetAllTasks()
        {
            return ctx.Tasks.ToList();
        }

        public TaskItem GetTaskById(int taskId)
        {
            return ctx.Tasks.Where(t => t.TaskId == taskId).FirstOrDefault();
        }

        public bool Save()
        {
            return ctx.SaveChanges() > 0;
        }
    }
}
