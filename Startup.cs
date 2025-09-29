using EPiServer.Cms.Shell;
using EPiServer.Cms.Shell.UI.Configurations;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Framework.Localization;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Optimizely002.Business.Extensions;
using Optimizely002.Services;
using Optimizely002.Services.Interfaces;

namespace Optimizely002;

public class Startup
{
    private readonly IWebHostEnvironment _webHostingEnvironment;

    public Startup(IWebHostEnvironment webHostingEnvironment)
    {
        _webHostingEnvironment = webHostingEnvironment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        if (_webHostingEnvironment.IsDevelopment())
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(_webHostingEnvironment.ContentRootPath, "App_Data"));

            services.Configure<SchedulerOptions>(options => options.Enabled = false);
        }

        services
            .AddCmsAspNetIdentity<ApplicationUser>()
            .AddCms()
            .AddNackademin()
            .AddAdminUserRegistration()
            .AddEmbeddedLocalization<Startup>();

        services.Configure<UploadOptions>(x => { x.FileSizeLimit = 52438800; });

        services.AddScoped<IDescendantService, DescendantService>();
        services.AddScoped<IXmlSitemapService, XmlSitemapService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStatusCodePages(async context =>
        {
            var httpContext = context.HttpContext;

            if (httpContext.Response.StatusCode == 404)
            {
                var path = httpContext.Request.Path.Value?.ToLowerInvariant();
                var cultureSegment = "en";

                switch (path.Split('/', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault())
                {
                    case "sv":
                        cultureSegment = "sv";
                        break;
                    case "en":
                        cultureSegment = "en";
                        break;
                    default:
                        cultureSegment = "en";
                        break;
                }


                httpContext.Response.Redirect($"/{cultureSegment}/error");

                await Task.Yield();
            }

        });

        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapContent();
        });
    }
}
