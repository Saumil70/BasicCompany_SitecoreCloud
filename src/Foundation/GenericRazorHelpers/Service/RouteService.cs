namespace GenericRazorHelpers.Service
{
    public class RouteService
    {
        private Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Route _route;

        public Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Route GetRoute()
        {
            return _route;
        }

        public void SetRoute(Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Route route)
        {
            _route = route;
        }

        public Context Context(Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Route route)
        {
            Context context = new Context();
            context.Name = route.Name;
            context.DatabaseName = route.DatabaseName;
            context.DeviceId = route.DeviceId;
            context.ItemId = route.ItemId;
            context.ItemLanguage = route.ItemLanguage;
            context.ItemVersion = route.ItemVersion;
            context.LayoutId = route.LayoutId;
            context.TemplateId = route.TemplateId;
            context.TemplateName = route.TemplateName;
            context.Fields = route.Fields;

            return context;
        }

    }

}
