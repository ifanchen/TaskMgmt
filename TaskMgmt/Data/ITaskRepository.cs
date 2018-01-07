using System.Collections.Generic;

namespace TaskMgmt.Data
{
    public interface ITaskRepository
    {
        IEnumerable<TaskItem> GetAllTasks();

        TaskItem GetTaskById(int taskId);

        void AddTask(TaskItem newTask);

        bool Save();
    }
}
