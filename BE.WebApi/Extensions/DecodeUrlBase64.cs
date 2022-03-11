using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.WebApi.Extensions
{
    public static class DecodeUrlBase64Extension
    {
        public static byte[] DecodeBase64(this string content)
        {
            content = content.Replace('-', '+').Replace('_', '/').PadRight(4 * ((content.Length + 3) / 4), '=');
            return Convert.FromBase64String(content);
        }
    }
}
