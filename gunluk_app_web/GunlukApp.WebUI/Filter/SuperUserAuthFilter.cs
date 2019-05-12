using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GunlukApp.WebUI.Filter
{
    public class SuperUserAuthFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("SessionSuperUsername") == null)
            {
                context.Result = new RedirectResult("/Anasayfa/Index/");
            }
        }
    }
}
