using AspNetBuilerplate.Sample1.Tasks;
using AspNetBuilerplate.Sample1.Tasks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetBuilerplate.Sample1.Web.Models.Tasks
{
    public class IndexViewModel
    {
        public IReadOnlyList<TaskListDto> Tasks { get; }

        public IndexViewModel(IReadOnlyList<TaskListDto> tasks)
        {
            Tasks = tasks;
        }

        public string GetTaskLabel(TaskListDto task)
        {
            switch (task.State)
            {
                case TaskState.Open:
                    return "label-success";
                default:
                    return "label-default";
            }
        }
    }
}