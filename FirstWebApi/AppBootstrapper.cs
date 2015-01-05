namespace FirstWebApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Nancy;
    using Nancy.Conventions;

    public class AppBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            // 不使用route module, 使用固定內容route
            nancyConventions.StaticContentsConventions.AddDirectory("docs", "swagger-ui");
        }
    }
}