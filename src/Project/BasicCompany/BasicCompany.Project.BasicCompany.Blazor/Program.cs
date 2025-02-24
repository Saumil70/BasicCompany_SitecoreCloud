using BasicCompany.Blazor.Configuration;
using BasicCompany.Blazor.Extensions;
using BasicCompany.Blazor.RestGateway;
using GenericRazorHelpers.Service;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Sitecore.AspNet.ExperienceEditor;
using Sitecore.AspNet.RenderingEngine.Extensions;
using Sitecore.AspNet.RenderingEngine.Localization;
using Sitecore.AspNet.Tracking;
using Sitecore.LayoutService.Client.Extensions;
using Sitecore.LayoutService.Client.Newtonsoft.Extensions;
using Sitecore.LayoutService.Client.Request;
using System.Globalization;
using GenericRazorHelpers.Localizer;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Bind SitecoreOptions from configuration
var sitecoreOptions = builder.Configuration.GetSection(SitecoreOptions.Key).Get<SitecoreOptions>();
builder.Services.Configure<SitecoreOptions>(builder.Configuration.GetSection(SitecoreOptions.Key));

var _defaultLanguage = "en";
var _supportedCultures = new List<CultureInfo> { new(_defaultLanguage) };

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services
    .AddRouting()
    .AddLocalization(options => options.ResourcesPath = "Resources")
    .AddMvc()
    .AddNewtonsoftJson(o => o.SerializerSettings.SetDefaults());

builder.Services.AddControllers();

// Dictionary registrations
builder.Services.Configure<SitecoreLocalizerOptions>(options => options.Cultures = _supportedCultures);
builder.Services.AddHttpClient<ISitecoreLocalizer, SitecoreLocalizer>("sitecoreLocalizer", client =>
{
    client.BaseAddress = sitecoreOptions.DictionaryServiceUri;
});

builder.Services.AddTransient<ISitecoreLocalizer, SitecoreLocalizer>();
builder.Services.AddTransient<IStringLocalizer, SitecoreLocalizer>();

// Register the Sitecore Layout Service Client
builder.Services.AddSitecoreLayoutService()
    .WithDefaultRequestOptions(request =>
    {
        request
            .SiteName(sitecoreOptions.DefaultSiteName)
            .ApiKey(sitecoreOptions.ApiKey);
    })
    .AddHttpHandler("default", sitecoreOptions.LayoutServiceUri)
    .AsDefaultHandler();

// Register the Sitecore Rendering Engine services
builder.Services.AddSitecoreRenderingEngine(options =>
{
    options
        .AddFeatureBasicContent()
        .AddFeatureNavigation()
        .AddFeatureProducts()
        .AddFeatureServices()
        .AddDefaultPartialView("_ComponentNotFound");
})
.ForwardHeaders()
.WithTracking()
.WithExperienceEditor(req => req.JssEditingSecret = sitecoreOptions.JssEditingSecret);

// Enable support for robot detection
builder.Services.AddSitecoreVisitorIdentification(options =>
{
    options.SitecoreInstanceUri = sitecoreOptions.InstanceUri;
});

builder.Services.AddSingleton<RouteService>();
builder.Services.AddScoped<IRestGatewayManager, RestGatewayManager>();

var app = builder.Build();
//app.UseMiddleware<BlazorRequestMiddleware>();
// Configure the HTTP request pipeline
app.UseForwardedHeaders(ConfigureForwarding(app.Environment));

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

if (sitecoreOptions.EnableExperienceEditor)
{
    app.UseSitecoreExperienceEditor();
}

app.UseRouting();
app.UseStaticFiles();
app.MapBlazorHub();

// Enable ASP.NET Core Localization
app.UseRequestLocalization(options =>
{
    var supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("en"),  // English
        new CultureInfo("hi-IN") // Hindi
    };

    options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    options.UseSitecoreRequestLocalization();
});

// Enable proxying of Sitecore robot detection scripts
app.UseSitecoreVisitorIdentification();

app.MapControllerRoute(
    "error",
    "error",
    new { controller = "Default", action = "Error" }
);

// Enables the default Sitecore URL pattern with a language prefix
app.MapSitecoreLocalizedRoute("sitecore", "Index", "Default");

// Fall back to language-less routing as well, and use the default culture (en)
app.MapFallbackToController("Index", "Default");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        "localization",
        "api/localization/reload",
        new { controller = "Localization", action = "Reload" }
    );
});

Task.Run(async () => await app.Services.GetRequiredService<ISitecoreLocalizer>().Reload()).Wait();

app.Run();

ForwardedHeadersOptions ConfigureForwarding(IWebHostEnvironment env)
{
    var options = new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
    };
    if (env.IsDevelopment())
    {
        options.KnownNetworks.Clear();
        options.KnownProxies.Clear();
    }
    else
    {
        // TODO: Configure forwarding options for production
    }

    return options;
}
