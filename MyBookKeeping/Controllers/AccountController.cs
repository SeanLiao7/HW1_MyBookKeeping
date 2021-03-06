﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using MyBookKeeping.Models;
using MyBookKeeping.Repositories;
using MyBookKeeping.Service;

namespace MyBookKeeping.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;

        /// <summary>
        /// 設定要存在 FormsAuthenticationTicket 中的資料，這裡用來儲存角色資訊
        /// </summary>
        private string _userData = "";

        public AccountController( )
        {
            var unitOfWork = new EFUnitOfWork( );
            _accountService = new AccountService( unitOfWork );
        }

        public ActionResult Login( )
        {
            return View( );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login( LoginModel loginModel )
        {
            if ( validateLogin( loginModel ) )
            {
                // 登入時清空所有 Session 資料
                Session.RemoveAll( );

                var ticket = new FormsAuthenticationTicket( 1,
                    loginModel.Account, // 你想要存放在 User.Identy.Name 的值，通常是使用者帳號
                    DateTime.Now,
                    DateTime.Now.AddMinutes( 30 ),
                    false, // 將管理者登入的 Cookie 設定成 Session Cookie
                    _userData, // userdata 看你想存放啥
                    FormsAuthentication.FormsCookiePath );

                var encTicket = FormsAuthentication.Encrypt( ticket );

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

        public ActionResult Register( )
        {
            ViewData[ "roles" ] = getRolesSelectedItems( );
            return View( );
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register( [Bind( Exclude = "UserId, CreateBy, UpdateBy, UpdateOn" )] SystemUser user, string[ ] roles )
        {
            if ( ModelState.IsValid )
            {
                updateUserAndRoleRelation( user, roles );
                user.CreateBy = Guid.NewGuid( );
                user.Password = Crypto.HashPassword( user.Password );
                _accountService.createNewUser( user );
                _accountService.save( );
                return RedirectToAction( "Index", "Record" );
            }

            ViewData[ "roles" ] = getRolesSelectedItems( );
            return View( );
        }

        private List<SelectListItem> getRolesSelectedItems( )
        {
            var roles = _accountService
                .getRoles( )
                .OrderBy( x => x.Sort )
                .ToList( );

            var items = new List<SelectListItem>( );
            foreach ( var role in roles )
            {
                items.Add( new SelectListItem
                {
                    Text = role.Name,
                    Value = role.RoleId.ToString( ),
                    Selected = false
                } );
            }

            return items;
        }

        private void updateUserAndRoleRelation( SystemUser user, string[ ] selectedRoleIds )
        {
            if ( user.SystemRoles == null )
                user.SystemRoles = new List<SystemRole>( );

            if ( selectedRoleIds != null )
            {
                var roles = _accountService.getRoles( ).ToList( );

                foreach ( var role in roles )
                {
                    if ( selectedRoleIds.Contains( role.RoleId.ToString( ) ) )
                    {
                        user.SystemRoles.Add( role );
                    }
                }
            }
        }

        /// <summary>
        /// 驗證使用者是否登入成功
        /// </summary>
        /// <param name="loginModel">使用者輸入資料</param>
        /// <returns>登入是否成功</returns>
        private bool validateLogin( LoginModel loginModel )
        {
            // 驗證帳號是否存在
            var user = _accountService
                .getUsers( )
                .Include( "SystemRoles" )
                .SingleOrDefault( x => x.Account == loginModel.Account );
            if ( user == null )
                return false;

            // 驗證密碼是否正確
            var password = user.Password;
            if ( Crypto.VerifyHashedPassword( password, loginModel.PassWord ) == false )
                return false;

            // 授權：設定角色到 _userData
            _userData = string.Join( ",", user.SystemRoles.Select( x => x.Name ) );

            return true;
        }
    }
}