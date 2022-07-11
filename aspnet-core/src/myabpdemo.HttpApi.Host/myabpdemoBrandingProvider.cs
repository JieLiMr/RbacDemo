using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace myabpdemo
{
    [Dependency(ReplaceServices = true)]
    public class myabpdemoBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "myabpdemo";
    }
}
