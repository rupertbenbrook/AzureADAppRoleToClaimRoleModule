using System;
using System.Security.Claims;
using System.Web;

namespace ClaimsRolesToRolesModule
{
    // https://blogs.msdn.microsoft.com/waws/2017/03/09/azure-app-service-authentication-app-roles/

    public class ClaimsRolesToRolesModule : IHttpModule
    {

        public void Init(HttpApplication context)
        {
            ModuleTrace.ModuleInit();
            context.PostAuthenticateRequest += OnPostAuthenticateRequest;
        }

        public void Dispose()
        {
            ModuleTrace.ModuleDispose();
        }

        private void OnPostAuthenticateRequest(object sender, EventArgs e)
        {
            ModuleTrace.ModulePostAuthenticate();
            if (ClaimsPrincipal.Current.Identity.IsAuthenticated)
            {
                ClaimsIdentity claimsIdentity = ClaimsPrincipal.Current.Identity as ClaimsIdentity;
                foreach (var claim in ClaimsPrincipal.Current.FindAll("roles"))
                {
                    var roleClaim = new Claim(claimsIdentity.RoleClaimType, claim.Value);
                    claimsIdentity.AddClaim(claim);
                    ModuleTrace.ClaimCopy(claim, roleClaim);
                }
            }
        }
    }
}