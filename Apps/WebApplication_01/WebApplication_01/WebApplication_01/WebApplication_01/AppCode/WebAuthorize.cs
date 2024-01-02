using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication_01.AppConsts;

namespace WebApplication_01.AppCode
{
    public class WebAuthorize : Attribute, IAuthorizationFilter
    {
        private readonly int[] _actionAccess;

        public WebAuthorize(params int[] actionAccess)
        {
            _actionAccess = actionAccess;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var isLoggedIn = IsLoggedIn(context.HttpContext);

            if (!isLoggedIn)
                throw new AuthenticationException(MessageConsts.NotLoggedIn);


            var userAccess = GetUserClaims(context.HttpContext);

            if (!_actionAccess.Any(p => userAccess.Contains(p)))
                throw new AuthenticationException(MessageConsts.NotAccess);

        }

        private static bool IsLoggedIn(HttpContext context)
        {
            return context.User != null &&
                   context.User.Identity.IsAuthenticated;
        }

        private static IEnumerable<int> GetUserClaims(HttpContext context)
        {
            var userClaim = GetUserClaim(context);

            return userClaim
                       .Split(",")
                       .ToList()
                       .ConvertAll(int.Parse);
        }


        private static string GetUserClaim(HttpContext context)
        {
            return context
                      .User
                      .Claims
                      .FirstOrDefault(p => p.Type == WebAuthorizeConsts.UserAccess)?
                      .Value;
        }


    }
}
