using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace myabpdemo.Data
{
    /* This is used if database provider does't define
     * ImyabpdemoDbSchemaMigrator implementation.
     */
    public class NullmyabpdemoDbSchemaMigrator : ImyabpdemoDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}