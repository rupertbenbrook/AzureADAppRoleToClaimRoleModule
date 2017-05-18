using System.Diagnostics;
using System.Security.Claims;

namespace AzureADAppRoleToClaimRoleModule
{
    public static class ModuleTrace
    {
        public static void ModuleInit()
        {
            Trace.TraceInformation("AzureADAppRoleToClaimRoleModule: Init");
        }

        public static void ModuleDispose()
        {
            Trace.TraceInformation("AzureADAppRoleToClaimRoleModule: Dispose");
        }

        public static void ModulePostAuthenticate()
        {
            Trace.TraceInformation("AzureADAppRoleToClaimRoleModule: Post Authenticate");
        }

        public static void AddedClaim(Claim claim)
        {
            Trace.TraceInformation("AzureADAppRoleToClaimRoleModule: Added claim {0}", claim);
        }
    }
}