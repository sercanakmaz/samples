using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AspNetBuilerplate.Sample1.Tasks.Dto;
using Abp.Domain.Repositories;
using Abp.Collections.Extensions;
using Abp.Linq;

namespace AspNetBuilerplate.Sample1.Tasks
{
    public class TaskAppService : Sample1AppServiceBase, ITaskAppService
    {
        private readonly IRepository<Task> _taskRepository = null;
        public TaskAppService(IRepository<Task> taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<ListResultDto<TaskListDto>> GetAll(GetAllTasksInput input)
        {
            var tasks = _taskRepository
                .GetAll()
                .WhereIf(input.State.HasValue, t => t.State == input.State.Value)
                .OrderByDescending(t => t.CreationTime)
                .ToList();

            return new ListResultDto<TaskListDto>(
                ObjectMapper.Map<List<TaskListDto>>(tasks)
            );
        }
    }
}
