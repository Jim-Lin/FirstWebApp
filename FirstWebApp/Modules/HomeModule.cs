namespace FirstWebApp.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Nancy;

    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            this.Get["/"] = parameters =>
            {
                return View["Index"];
            };
        }
    }
}