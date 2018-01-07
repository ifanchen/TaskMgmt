using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskMgmt.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using TaskMgmt.Data;

namespace TaskMgmt.Controllers
{    
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private readonly IHostingEnvironment environment;
        private readonly ITaskRepository repository;

        public TasksController(IHostingEnvironment environment, ITaskRepository repository)
        {            
            this.environment = environment;
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<TaskDetailViewModel> Get()
        {
            var tasksViewModel = new List<TaskDetailViewModel>();
            var tasks = this.repository.GetAllTasks();
            foreach(var task in tasks)
            {
                var taskViewModel = new TaskDetailViewModel
                {
                    Id = task.TaskId,
                    TaskName = task.Name,
                    TaskStatus = task.Status,
                    FileName = task.FileName
                };
                
                tasksViewModel.Add(taskViewModel);
            }

            return tasksViewModel;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm]TaskViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Insert into DB
            var task = new TaskItem
            {
                Name = vm.TaskName
            };

            if (vm.TaskFile != null && vm.TaskFile.Length > 0)
            {
                task.FileName = vm.TaskFile.FileName;
                task.FileContentType = vm.TaskFile.ContentType;
            }

            repository.AddTask(task);
            repository.Save();

            // Upload file into storage
            if (vm.TaskFile != null && vm.TaskFile.Length > 0)
            {
                var filePath = Path.Combine(this.environment.ContentRootPath, @"FileStorage", vm.TaskFile.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await vm.TaskFile.CopyToAsync(stream);
                }
            }

            return Created("", task);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult Close(int id)
        {
            var task = repository.GetTaskById(id);
            if (task != null)
            {
                task.Status = true;
                repository.Save();
            }
            return Ok();
        }

        [HttpGet("[action]/{id}")]
        public IActionResult Download(int id)
        {
            var task = repository.GetTaskById(id);
            if (task != null)
            {
                HttpContext.Response.ContentType = task.FileContentType;
                var filePath = Path.Combine(this.environment.ContentRootPath, @"FileStorage", task.FileName);
                if (System.IO.File.Exists(filePath))
                {
                    FileContentResult result = new FileContentResult(System.IO.File.ReadAllBytes(filePath), task.FileContentType)
                    {
                        FileDownloadName = task.FileName
                    };

                    return result;
                }                
            }

            return Content("File Not Found");
        }
    }
}
