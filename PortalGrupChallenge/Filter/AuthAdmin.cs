﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalGrupChallenge.Filter
{
    public class AuthAdmin : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = HttpContext.Current.Session["login"] as User;
            if (user != null && user.IsAdmin == false)
            {
                filterContext.Result = new RedirectResult("/Home/AccessDenied");

            }
        }
    }
}
