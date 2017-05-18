using System.Diagnostics;
using System.Security.Claims;

namespace ClaimsRolesToRolesModule
{
    public static class ModuleTrace
    {
        public static void ModuleInit()
        {
            Trace.TraceInformation("ClaimsRolesToRolesModule: Init");
        }

        public static void ModuleDispose()
        {
            Trace.TraceInformation("ClaimsRolesToRolesModule: Dispose");
        }

        public static void ModulePostAuthenticate()
        {
            Trace.TraceInformation("ClaimsRolesToRolesModule: Post Authenticate");
        }

        public static void AddedClaim(Claim claim)
        {
            Trace.TraceInformation("ClaimsRolesToRolesModule: Added claim {0}", claim);
        }
    }
}