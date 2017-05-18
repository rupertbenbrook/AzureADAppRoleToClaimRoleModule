# Introduction
An IIS HTTP Module to copy over the Azure AD application role claims to ClaimsIdentity role claims,
enabling the use of roles in standard ASP.NET role-based authorization. This includes the Web.config <authorization> section,
ASP.NET MVC [Authorize(Roles = "***")] attributes, and calls to User.IsInRole("***") within the code.

## Why is this needed?
When you define Azure AD application roles for your application the claims passed by Azure AD to your application
use the claim type "roles". However, the ASP.NET ClaimsIdentity class expects roles to use the claim type "http://schemas.microsoft.com/ws/2008/06/identity/claims/role". Copying over the values from the Azure AD claim type
to the ClaimsIdentity claim type then enables Azure AD application role names to be used in defining ASP.NET
role-based authorization rules.

This is useful when migrating ASP.NET-based web applications from Windows authentication on IIS to Azure AD
authentication in Azure App Service, with Azure AD application roles. As a module, it can be dropped into an
application without needing to modify the code, and so long as the Azure AD role names match up with the role
names the application expects, authorization will work as intended.

## Credits
The code for this project is based on code by Jeff Sanders in his example of using Azure AD application roles with
Azure App Service authentication:
https://blogs.msdn.microsoft.com/waws/2017/03/09/azure-app-service-authentication-app-roles/

# Installation
* Copy AzureADAppRoleToClaimRoleModule.dll and AzureADAppRoleToClaimRoleModule.pdb to the website bin/ folder
* Update the Web.config to load the module:
```xml
<configuration>
  <system.web>
    <httpModules>
      <add name="AzureADAppRoleToClaimRoleModule" type="AzureADAppRoleToClaimRoleModule.AzureADAppRoleToClaimRoleModule, AzureADAppRoleToClaimRoleModule"/>
    </httpModules>
  </system.web>
  <system.webServer>
    <modules>
      <add name="AzureADAppRoleToClaimRoleModule" type="AzureADAppRoleToClaimRoleModule.AzureADAppRoleToClaimRoleModule, AzureADAppRoleToClaimRoleModule" />
    </modules>
  </system.webServer>
</configuration>
```

# Troubleshooting
TODO
