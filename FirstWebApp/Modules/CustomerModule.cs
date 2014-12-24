﻿namespace FirstWebApp.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using FirstWebApp.Models;
    using Nancy;
    using Nancy.ModelBinding;

    public class CustomerModule : NancyModule
    {
        public CustomerModule(AppService appService) : base("/customer")
        {
            this.Get["/"] = parameters =>
            {
                // Razor
                // 1. 先用匿名型別產生匿名物件再可列舉
                // 2. 由匿名物件的值轉為dynamic物件(實際上為ExpandoObject物件)
                // IEnumerable<dynamic> custList = webAppService.Entities.Customer
                //    .Select(c => new { Id = c.Id, CustName = c.CustName, Created = c.Created }).AsEnumerable()
                //    .Select(x => new { Id = x.Id, CustName = x.CustName, Created = x.Created }.ToDynamic());

                // Super Simple View Engine
                // 匿名型別產生匿名物件
                /// var custList = appService.Entities.Customer.Select(c => new { Id = c.Id, CustName = c.CustName, Created = c.Created });

                IList<Customer> custList = appService.FindCustomers();
                appService.Logger.Info("test NLog");
                appService.Logger.Debug(custList.ToArray<dynamic>()[0].CustName);
                
                return Negotiate.WithModel(custList).WithView("ListS.sshtml");
            };

            this.Get["/new"] = parameters =>
            {
                return View["NewS.sshtml", new Customer()];
            };

            this.Post["/new"] = parameters =>
            {
                appService.AddCustomer(this.Bind<Customer>());

                return Response.AsRedirect("/customer");
            };

            this.Get["/{id:int}"] = parameters =>
            {
                int id = (int)parameters.id;
                Customer cust = appService.GetCustomerById(id);
                if (cust != null)
                {
                    return View["ViewS.sshtml", cust];
                }
                else
                {
                    return Response.AsRedirect("/customer");
                }
            };

            this.Post["/update/{id:int}"] = parameters =>
            {
                Customer c = this.Bind<Customer>();
                Customer cust = appService.GetCustomerById(c.Id);
                cust.CustName = c.CustName;
                appService.UpdateCustomer(cust);

                return Response.AsRedirect("/customer");
            };

            this.Post["/delete/{id:int}"] = parameters =>
            {
                Customer cust = appService.GetCustomerById(parameters.Id);
                appService.DeleteCustomer(cust);

                return Response.AsRedirect("/customer");
            };
        }
    }
}