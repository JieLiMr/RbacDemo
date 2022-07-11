using System.Threading.Tasks;

namespace myabpdemo.Data
{
    public interface ImyabpdemoDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
