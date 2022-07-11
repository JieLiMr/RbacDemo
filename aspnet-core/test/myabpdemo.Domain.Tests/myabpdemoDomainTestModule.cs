using myabpdemo.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace myabpdemo
{
    [DependsOn(
        typeof(myabpdemoEntityFrameworkCoreTestModule)
        )]
    public class myabpdemoDomainTestModule : AbpModule
    {

    }
}