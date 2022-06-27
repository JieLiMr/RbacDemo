using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDto.Admin
{
    public class CaptchaResult
    {
        /// <summary>
        /// CaptchaCode
        /// </summary>
        public string CaptchaCode { get; set; }

        /// <summary>
        /// CaptchaMemoryStream
        /// </summary>
        public MemoryStream CaptchaMemoryStream { get; set; }

        /// <summary>
        /// Timestamp
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
