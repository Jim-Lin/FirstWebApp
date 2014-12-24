namespace FirstWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using NLog;

    public class AppService
    {
        private static Logger logger;
        private FirstEntities entities;

        public AppService()
        {
            this.entities = new FirstEntities();
            AppService.logger = LogManager.GetCurrentClassLogger();
        }

        public Logger Logger
        {
            get
            {
                return AppService.logger;
            }
        }

        public IList<Customer> GetCustomers()
        {
            return this.entities.Customer.ToList<Customer>();
        }

        public Customer GetCustomerById(int id)
        {
            return this.entities.Customer.Where<Customer>(c => c.Id == id).FirstOrDefault<Customer>();
        }

        public void AddCustomer(Customer cust)
        {
            cust.Created = System.DateTime.Now;
            cust.Modified = System.DateTime.Now;
            this.entities.Customer.Add(cust);
            this.entities.SaveChanges();
        }

        public void UpdateCustomer(Customer cust)
        {
            cust.Modified = System.DateTime.Now;
            this.entities.SaveChanges();
        }
    }
}