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

        public static void ClaimCopy(Claim source, Claim destination)
        {
            Trace.TraceInformation("ClaimsRolesToRolesModule: Copied claim {0} to claim {1}", source, destination);
        }
    }
}