﻿
Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Shared Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
        filters.Add(New HandleErrorAttribute())
    End Sub

    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        ' MapRoute takes the following parameters, in order:
        ' (1) Route name
        ' (2) URL with parameters
        ' (3) Parameter defaults
        routes.MapRoute(
            "Default",
            "{controller}/{action}/{id}",
            New With {.controller = "Home", .action = "Settings", .id = UrlParameter.Optional}
        )

    End Sub

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()

        RegisterGlobalFilters(GlobalFilters.Filters)
        RegisterRoutes(RouteTable.Routes)
    End Sub
End Class
