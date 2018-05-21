using CredibleBehavioralHealth.Barcode.BL.Service;
using CredibleBehavioralHealth.Barcode.Common;
using CredibleBehavioralHealth.Email;
using CredibleBehavioralHealth.QRCode;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;

namespace CredibleBehavioralHealth.Barcode.API
{
    /// <summary>
    /// 
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// 
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            log4net.Config.XmlConfigurator.Configure();

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            container.Register<ILogger, Logger>(Lifestyle.Singleton);
            container.Register<IService, Service>(Lifestyle.Scoped);
            container.Register<IEmailService, EmailService>(Lifestyle.Singleton);
            container.Register<IQRCodeGenerator, QRCodeGenerator>(Lifestyle.Singleton);
            

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

        }
    }
}
