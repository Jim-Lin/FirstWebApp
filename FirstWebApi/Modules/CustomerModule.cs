namespace FirstWebApi.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using FirstWebApi.Models;
    using Nancy;

    public class CustomerModule : NancyModule
    {
        public CustomerModule()
            : base("/customer")
        {
            this.Get["GetCustomers", "/"] = parameters => new[]
            {
                new Customer { CustName = "Vincent Vega", Created = System.DateTime.Now, Modified = System.DateTime.Now }
            };
        }
    }
}