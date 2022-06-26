using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDto
{
    public class AddAdmin
    {
        public DateTime LastLoginTime;
        public DateTime CreateTime;
        public string LastLoginIP { get; set; }

        ///<summary>
        ///用户名
        ///</summary>
        public string UserName { get; set; }

        ///<summary>
        ///密码
        ///</summary>
        public string Password { get; set; }

        ///<summary>
        ///邮箱
        ///</summary>
        public string Email { get; set; }

    }
}
