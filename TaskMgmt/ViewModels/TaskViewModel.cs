using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskMgmt.ViewModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public bool TaskStatus { get; set; }
        public IFormFile TaskFile { get; set; }

        
    }
}
