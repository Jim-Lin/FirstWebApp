namespace FirstWebApp.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Core.EntityClient;
    using System.Linq;
    using System.Web;
    using FirstWebApp.Models;
    using Nancy;
    using Nancy.ModelBinding;

    public class CustomerModule : NancyModule
    {
        public CustomerModule(WebAppService webAppService) : base("/customer")
        {
            this.Get["/"] = parameters =>
            {
                // Razor
                // 1. 先用匿名型別產生匿名物件再可列舉
                // 2. 由匿名物件的值轉為dynamic物件(實際上為ExpandoObject物件)
                //IEnumerable<dynamic> custList = webAppService.Entities.Customer
                //    .Select(c => new { Id = c.Id, CustName = c.CustName, Created = c.Created }).AsEnumerable()
                //    .Select(x => new { Id = x.Id, CustName = x.CustName, Created = x.Created }.ToDynamic());

                // Super Simple View Engine
                // 匿名型別產生匿名物件
                var custList = webAppService.Entities.Customer
                    .Select(c => new { Id = c.Id, CustName = c.CustName, Created = c.Created });

                webAppService.Logger.Info("test NLog");
                webAppService.Logger.Debug(custList.ToArray<dynamic>()[0].CustName);
                
                return Negotiate.WithModel(custList).WithView("ListS.sshtml");
            };

            this.Get["/new"] = parameters =>
            {
                return View["NewS.sshtml", new Customer()];
            };

            this.Post["/new"] = parameters =>
            {
                Customer c = this.Bind<Customer>();
                c.Created = System.DateTime.Now;
                webAppService.Entities.Customer.Add(c);
                webAppService.Entities.SaveChanges();

                return Response.AsRedirect("/customer");
            };

            this.Get["/{id:int}"] = parameters =>
            {
                int id = (int)parameters.id;
                Customer cust = webAppService.Entities.Customer.Where<Customer>(c => c.Id == id).FirstOrDefault<Customer>();
                if (cust != null)
                {
                    return View["ViewS.sshtml", cust];
                }
                else
                {
                    return Response.AsRedirect("/customer");
                }
            };
        }
    }
}