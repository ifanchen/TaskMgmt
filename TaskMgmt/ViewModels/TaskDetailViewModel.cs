using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskMgmt.ViewModels
{
    public class TaskDetailViewModel
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public bool TaskStatus { get; set; }
        public string FileName { get; set; }
    }
}
