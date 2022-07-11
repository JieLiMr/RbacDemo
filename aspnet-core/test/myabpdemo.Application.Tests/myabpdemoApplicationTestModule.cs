using Volo.Abp.Modularity;

namespace myabpdemo
{
    [DependsOn(
        typeof(myabpdemoApplicationModule),
        typeof(myabpdemoDomainTestModule)
        )]
    public class myabpdemoApplicationTestModule : AbpModule
    {

    }
}