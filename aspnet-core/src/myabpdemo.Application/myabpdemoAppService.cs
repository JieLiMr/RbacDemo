using System;
using System.Collections.Generic;
using System.Text;
using myabpdemo.Localization;
using Volo.Abp.Application.Services;

namespace myabpdemo
{
    /* Inherit your application services from this class.
     */
    public abstract class myabpdemoAppService : ApplicationService
    {
        protected myabpdemoAppService()
        {
            LocalizationResource = typeof(myabpdemoResource);
        }
    }
}
