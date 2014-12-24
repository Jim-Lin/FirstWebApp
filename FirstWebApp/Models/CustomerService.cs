namespace FirstWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using NLog;

    public class CustomerService : IAppService<Customer>
    {
        private FirstEntities entities;

        public CustomerService()
        {
            this.entities = new FirstEntities();
        }

        public IList<Customer> FindRecords()
        {
            return this.entities.Customer.ToList<Customer>();
        }

        public Customer GetRecordByName(string name)
        {
            return this.entities.Customer.SingleOrDefault<Customer>(c => c.CustName.Equals(name));
        }

        public Customer GetRecordById(int id)
        {
            return this.entities.Customer.Where<Customer>(c => c.Id == id).FirstOrDefault<Customer>();
        }

        public void AddRecord(Customer cust)
        {
            cust.Created = System.DateTime.Now;
            cust.Modified = System.DateTime.Now;
            this.entities.Customer.Add(cust);
            this.entities.SaveChanges();
        }

        public void UpdateRecord(Customer cust)
        {
            cust.Modified = System.DateTime.Now;
            this.entities.SaveChanges();
        }

        public void DeleteRecord(Customer cust)
        {
            this.entities.Customer.Remove(cust);
            this.entities.SaveChanges();
        }
    }
}