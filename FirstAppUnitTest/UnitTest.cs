namespace FirstAppUnitTest
{
    using System;
    using System.Collections.Generic;
    using FirstWebApp;
    using FirstWebApp.Services;
    using Xunit;

    public class UnitTest
    {
        private static FirstEntities entities = new FirstEntities();
        private AppService<Customer> custService = new CustomerService(entities);

        public static void Main() {}

        [Fact]
        public void TestCustName()
        {
            Assert.Equal("JimLin", this.custService.GetRecordById(2).CustName);
        }

        [Fact]
        public void TestOrderCount()
        {
            Assert.Equal(2, this.custService.GetRecordById(2).Order.Count);
        }

        [Fact]
        public void TestThrowsException()
        {
            Assert.Throws<System.ArgumentOutOfRangeException>(
                /// Customer list count is 4
                () =>
                {
                    IList<Customer> cust = this.custService.FindRecords();
                    return cust[10].Id;
                });
        }

        [Fact]
        public void TestAddAndDeleteCustomer()
        {
            this.AddCustomer();
            this.DeleteCustomer();
        }

        private void AddCustomer()
        {
            this.custService.AddRecord(new Customer { CustName = "TEST" });
            Assert.NotNull(this.custService.GetRecordByName("TEST"));
        }

        private void DeleteCustomer()
        {
            Customer cust = this.custService.GetRecordByName("TEST");
            if (cust != null)
            {
                this.custService.DeleteRecord(cust);
                Assert.Null(this.custService.GetRecordByName("TEST"));
            }
            else
            {
                Assert.NotNull(cust);
            }
        }
    }
}
