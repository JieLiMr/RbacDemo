using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDto.Admin
{
    public class UserInfor
    {
        ///<summary>
        ///管理员Id
        ///</summary>
        public long AdminId { get; set; }

        ///<summary>
        ///用户名
        ///</summary>
        public string UserName { get; set; }


        ///<summary>
        ///邮箱
        ///</summary>
        public string Email { get; set; }

        ///<summary>
        ///末次登录时间
        ///</summary>
        public DateTime LastLoginTime { get; set; }

        ///<summary>
        ///末次登录IP
        ///</summary>
        public string LastLoginIP { get; set; }

        ///<summary>
        ///是否锁定
        ///</summary>
        public bool IsLock { get; set; }
    }
}
