using myabpdemo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace myabpdemo.Permissions
{
    public class myabpdemoPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(myabpdemoPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(myabpdemoPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<myabpdemoResource>(name);
        }
    }
}
