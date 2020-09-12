using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobileWebService.Models;

namespace MobileWebService
{
    public class WxConfig
    {
        public static string AppID = "";
        public static string AppSecret = "";
        public static Dictionary<string, WxAuthInfo> s_OnlineSessionTable = new Dictionary<string, WxAuthInfo>();
        public static Dictionary<string, DateTime>   s_OnlineTimeTable = new Dictionary<string, DateTime>();

        public static string  Add(WxAuthInfo model)
        {
            string strSession = "";
            lock (s_OnlineSessionTable)
            {
                string  strGuid =  Guid.NewGuid().ToString().Replace("-", "");

                strSession = $"ehkey-{strGuid}";

                s_OnlineSessionTable.Add(strSession, model);
                s_OnlineTimeTable.Add(strSession, DateTime.Now);
            }

            return strSession;
        }

        public static bool Get()
        {

            return true;
        }

        public static bool List()
        {

            return true;
        }

    }
}
