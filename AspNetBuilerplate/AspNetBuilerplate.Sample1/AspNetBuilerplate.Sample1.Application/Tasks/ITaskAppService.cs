using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AspNetBuilerplate.Sample1.Tasks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetBuilerplate.Sample1.Tasks
{
    public interface ITaskAppService : IApplicationService
    {
        Task<ListResultDto<TaskListDto>> GetAll(GetAllTasksInput input);
    }    
}
