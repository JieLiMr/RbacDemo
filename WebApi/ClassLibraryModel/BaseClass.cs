using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Entity
{
    public class BaseClass
    {
        public DateTime CreateTime { get; set; }
        public int CreateId { get; set; }
        public bool IsDelete { get; set; }
    }
}
