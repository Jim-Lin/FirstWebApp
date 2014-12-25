namespace FirstWebApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using FirstWebApp.Services;
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.TinyIoc;
    using NLog;

    public class AppBootstrapper : DefaultNancyBootstrapper
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            container.Register<IAppService<Customer>, CustomerService>().AsSingleton();
            container.Register<Logger>(logger);
        }
    }
}