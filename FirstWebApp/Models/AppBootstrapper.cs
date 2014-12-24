namespace FirstWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.TinyIoc;

    public class AppBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            container.Register<AppService>().AsSingleton();
        }
    }
}