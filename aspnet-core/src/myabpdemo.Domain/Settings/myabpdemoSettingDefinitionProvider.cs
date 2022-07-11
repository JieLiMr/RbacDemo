using Volo.Abp.Settings;

namespace myabpdemo.Settings
{
    public class myabpdemoSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(myabpdemoSettings.MySetting1));
        }
    }
}
