using myabpdemo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace myabpdemo.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class myabpdemoController : AbpController
    {
        protected myabpdemoController()
        {
            LocalizationResource = typeof(myabpdemoResource);
        }
    }
}