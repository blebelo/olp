using Abp.MultiTenancy;
using OnlineLearningPlatform.Authorization.Users;

namespace OnlineLearningPlatform.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
