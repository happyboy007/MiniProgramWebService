using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileWebService.Models
{
    public class WxAuthInfo
    {
        public string session_key { get; set; }
        public string openid { get; set; }
        
        public long errcode { get; set; }

        public string errmsg { get; set; }

       
    }
}
