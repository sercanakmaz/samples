using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AspNetBuilerplate.Sample1.MultiTenancy.Dto;

namespace AspNetBuilerplate.Sample1.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultDto<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
