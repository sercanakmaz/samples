using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AspNetBuilerplate.Sample1.MultiTenancy;

namespace AspNetBuilerplate.Sample1.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}