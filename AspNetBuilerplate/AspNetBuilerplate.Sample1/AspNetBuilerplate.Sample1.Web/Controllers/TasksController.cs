using AspNetBuilerplate.Sample1.Tasks;
using AspNetBuilerplate.Sample1.Tasks.Dto;
using AspNetBuilerplate.Sample1.Web.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNetBuilerplate.Sample1.Web.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskAppService _taskAppService;

        public TasksController(ITaskAppService taskAppService)
        {
            _taskAppService = taskAppService;
        }

        public async Task<ActionResult> Index(GetAllTasksInput input)
        {
            var output = await _taskAppService.GetAll(input);
            var model = new IndexViewModel(output.Items);
            return View(model);
        }
    }
}