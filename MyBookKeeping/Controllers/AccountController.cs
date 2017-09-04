using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyBookKeeping.Models;

namespace MyBookKeeping.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// 設定要存在 FormsAuthenticationTicket 中的資料，這裡用來儲存角色資訊
        /// </summary>
        private string _userData = "";

        // GET: Login
        public ActionResult Login( )
        {
            return View( );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login( LoginModel loginModel )
        {
            // 登入的密碼（以 SHA1 加密）
            //Password = FormsAuthentication.HashPasswordForStoringInConfigFile( Password, "SHA1" );

            //這一條是去資料庫抓取輸入的帳號密碼的方法請自行實做
            //var r = loginModel;

            if ( validateLogin( loginModel ) )
            {
                // 登入時清空所有 Session 資料
                Session.RemoveAll( );

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket( 1,
                    loginModel.Account,//你想要存放在 User.Identy.Name 的值，通常是使用者帳號
                    DateTime.Now,
                    DateTime.Now.AddMinutes( 30 ),
                    false,//將管理者登入的 Cookie 設定成 Session Cookie
                    _userData,//userdata看你想存放啥
                    FormsAuthentication.FormsCookiePath );

                string encTicket = FormsAuthentication.Encrypt( ticket );

                Response.Cookies.Add( new HttpCookie( FormsAuthentication.FormsCookieName, encTicket ) );

                return RedirectToAction( "Index", "Record" );
            }

            ModelState.AddModelError( "password", "您輸入的帳號不存在或者密碼錯誤!" );

            return View( );
        }

        [HttpPost]
        public ActionResult LogOut( )
        {
            FormsAuthentication.SignOut( );
            Session.RemoveAll( );

            return RedirectToAction( "Index", "Record" );
        }

        /// <summary>
        /// 驗證使用者是否登入成功
        /// </summary>
        /// <param name="loginModel">使用者輸入資料</param>
        /// <returns>登入是否成功</returns>
        private bool validateLogin( LoginModel loginModel )
        {
            // 驗證

            // 請自行寫 Code 檢查 Username, Password 是否正確

            if ( loginModel == null || loginModel.Account != "123" || loginModel.PassWord != "123" )
                return false;

            // 授權：設定角色到 _userData
            _userData = "admin";

            return true;
        }
    }
}