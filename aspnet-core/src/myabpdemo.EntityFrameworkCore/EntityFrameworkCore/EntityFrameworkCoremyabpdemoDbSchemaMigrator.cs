using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using myabpdemo.Data;
using Volo.Abp.DependencyInjection;

namespace myabpdemo.EntityFrameworkCore
{
    public class EntityFrameworkCoremyabpdemoDbSchemaMigrator
        : ImyabpdemoDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoremyabpdemoDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the myabpdemoDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<myabpdemoDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
