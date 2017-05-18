# ClaimsRolesToRolesModule
# Introduction
This project implements an IIS Http Module to copy over the Azure AD application role claims to ClaimsIdentity role claims,
enabling the use of roles in standard ASP.NET authorization, such as web.config <authorization> sections,
ASP.NET MVC [Authorize(Role="***")] attributes, or calls to User.IsInRole("***") within the code.

This is useful when migrating ASP.NET-based web applications from Windows-based authentication on IIS to Azure AD based
authentication in Azure App Service, with Azure AD application roles.
