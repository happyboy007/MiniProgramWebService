using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

using MobileWebService.Models;
//using NHibernate.NetCore;
using NHibernate;

namespace MobileWebService.Controllers
{
    [ApiController]
    [Route("/auth")]
    public class AuthController : Controller
    {
        private ISessionFactory factory;
        public AuthController(ISessionFactory factory)
        {     
            this.factory = factory;

        }
        // GET: AuthController
        public ActionResult Index()
        {
            return View();
        }

        //// GET: AuthController/Details/5
        //[Route("login/{resCode}")]
        //public string  Login(string resCode)
        //{
        //    string appid = WxConfig.AppID;//  "wx7f9a03037d09f467";
        //    string appsecret = WxConfig.AppSecret;// "f39902021b1a83dc497d6fd085d96704";
        //    string url = $"https://api.weixin.qq.com/sns/jscode2session?"
        //               + $"appid={appid}&secret={appsecret}&js_code={resCode}"
        //               + $"&grant_type=authorization_code";

        //    Utils.HttpClient client = new Utils.HttpClient();

        //   string msg = client.Get(url);

        //    if (msg == "") return "";

        //   WxAuthInfo info = JsonSerializer.Deserialize<WxAuthInfo>(msg);
        //  //  msg = "";
        //    if(info.openid !=null && info.session_key!=null)
        //        msg = WxConfig.Add(info);

        //    return msg;
             
        //}

        [Route("login")]
        [HttpPost]
        public ActionResult<UserInfo>  Login([FromBody]UserInfo userinfo)
        {
            UserInfo resultInfo = new UserInfo();

            using (var session = factory.OpenSession())
            {
                IList<UserInfo> list = session.CreateQuery("from UserInfo u where u.LoginName=?")
                                              .SetString(0, userinfo.LoginName).List<UserInfo>();

                if (list.Count() < 1)
                {
                    list = session.CreateQuery("from UserInfo u where u.Mobile=?")
                                  .SetString(0, userinfo.LoginName).List<UserInfo>();
                }

                if (list.Count() < 1)
                {
                    resultInfo.ID = 10001;  //用户不存在,请联系统管理员!
                    return resultInfo;
                }

                if (list[0].Password != userinfo.Password)
                {
                    resultInfo.ID = 10002; //密码错误,请重新输入!
                    return resultInfo;
                }

                resultInfo = list[0];

               string strSession = OnlineInfo.Add(resultInfo);

                resultInfo.ID = 0;
                resultInfo.Password = strSession;

            }

            return resultInfo;

        }

        // GET: AuthController/Create
        [Route("list")]
        public ActionResult<IEnumerable<UserInfo>> List()
        {
            using (var session = factory.OpenSession())
            {
                var list = session.Query<UserInfo>();

                return list.ToList();
            
            }

        }

        // POST: AuthController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuthController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuthController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
