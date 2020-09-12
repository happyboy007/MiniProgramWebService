using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobileWebService.Models;

namespace MobileWebService
{
    public class OnlineInfo
    {
        private  static Dictionary<string, UserInfo> s_OnlineSessionTable = new Dictionary<string, UserInfo>();
        private  static Dictionary<string, DateTime> s_OnlineTimeTable = new Dictionary<string, DateTime>();
        public static string Add(UserInfo model)
        {
            string strSession = "";
            lock (s_OnlineSessionTable)
            {
                string strGuid = Guid.NewGuid().ToString().Replace("-", "");

                strSession = $"ehkey-{strGuid}";

                s_OnlineSessionTable.Add(strSession, model);
                s_OnlineTimeTable.Add(strSession, DateTime.Now);
            }

            return strSession;
        }
    }
}
