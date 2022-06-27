using ClassLibraryDto;
using ClassLibraryDto.Admin;
using Microsoft.AspNetCore.Mvc;
using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rbac.IApplication
{
    public interface IAdminService : IBaseService<Admin, AddAdmin>
    {
        ResultDto Register(AddAdmin obj);

        LoignDto Loign(AddAdmin obj);
        Task<CaptchaResult> GenerateCaptchaImageAsync();
    }
}
