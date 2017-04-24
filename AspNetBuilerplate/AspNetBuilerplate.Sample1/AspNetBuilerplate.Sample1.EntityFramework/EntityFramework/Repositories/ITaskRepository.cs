using Abp.Domain.Repositories;
using AspNetBuilerplate.Sample1.Tasks;
using System.Collections.Generic;

namespace AspNetBuilerplate.Sample1.EntityFramework.Repositories
{
    public interface ITaskRepository : IRepository<Task, long>
    {
        List<Task> GetAllWithPeople(int? assignedPersonId, TaskState? state);
    }
}
