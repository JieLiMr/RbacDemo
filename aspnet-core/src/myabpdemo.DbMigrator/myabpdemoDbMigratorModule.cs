using myabpdemo.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace myabpdemo.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(myabpdemoEntityFrameworkCoreModule),
        typeof(myabpdemoApplicationContractsModule)
        )]
    public class myabpdemoDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
