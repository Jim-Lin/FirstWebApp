namespace FirstWebApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using Nancy;
    using NLog;

    public class CustomerService : AppService<Customer>
    {
        public CustomerService(FirstEntities entities) : base(entities)
        {}

        public override Customer GetRecordByName(string name)
        {
            return this.Entity.SingleOrDefault<Customer>(c => c.CustName.Equals(name));
        }

        public override Customer GetRecordById(int id)
        {
            return this.Entity.Where<Customer>(c => c.Id == id).FirstOrDefault<Customer>();
        }

        public override void AddRecord(Customer cust)
        {
            cust.Created = System.DateTime.Now;
            cust.Modified = System.DateTime.Now;
            this.Entity.Add(cust);
            this.SaveChanges();
        }

        public override void UpdateRecord(Customer cust)
        {
            Customer c = this.GetRecordById(cust.Id);
            if (c != null)
            {
                c.CustName = cust.CustName;
                c.Modified = System.DateTime.Now;
                this.SaveChanges();
            }
        }

        public override void DeleteRecord(Customer cust)
        {
            this.Entity.Remove(cust);
            this.SaveChanges();
        }
    }
}