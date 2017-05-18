using System;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace AzureADAppRoleToClaimRoleModule
{
    public class AzureADAppRoleToClaimRoleModule : IHttpModule
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
                var roleClaims = ClaimsPrincipal.Current.FindAll("roles")
                    .Select(c => new Claim(claimsIdentity.RoleClaimType, c.Value))
                    .ToList();
                foreach (var claim in roleClaims)
                { 
                    claimsIdentity.AddClaim(claim);
                    ModuleTrace.AddedClaim(claim);
                }
            }
        }
    }
}