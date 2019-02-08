using FinalProject.Service.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.UI.Attributes
{
    public class RoleAttribute : AuthorizeAttribute
    {
        AccountService _service;
        private string[] _roles;
        public RoleAttribute(params string[] roles)
        {
            _roles = new string[roles.Length];
            Array.Copy(roles, _roles, roles.Length);
            _service = new AccountService();
        }


        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (_roles != null)
            {
                _service.RoleAttribute(httpContext.User.Identity.Name, _roles);
                return true;
            }
            HttpContext.Current.Response.Redirect("/Error/NotFound");
            return false;  
        }
            }   
        }