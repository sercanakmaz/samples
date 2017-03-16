using System.Threading.Tasks;
using Abp.Application.Services;
using AspNetBuilerplate.Sample1.Roles.Dto;

namespace AspNetBuilerplate.Sample1.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
