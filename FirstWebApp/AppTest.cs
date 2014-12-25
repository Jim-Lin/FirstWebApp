namespace FirstWebApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using FirstWebApp.Modules;
    using FirstWebApp.Services;
    using Nancy;
    using Nancy.Testing;
    using NLog;
    using Xunit;

    public class AppTest
    {
        private IAppService<Customer> custService = new CustomerService();

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

        // "Views" folder must copy paste to the "bin" folder
        [Fact]
        public void TestRouteExists()
        {
            // Given
            var bootstrapper = new ConfigurableBootstrapper(with =>
                {
                    with.Module<CustomerModule>();
                    with.Dependency(custService);
                    with.Dependency(LogManager.GetCurrentClassLogger());
                });

            var browser = new Browser(bootstrapper);

            // When
            var result = browser.Get("/customer/2", with => with.HttpRequest());

            // Then
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
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
                this.custService.DeleteRecord(cust.Id);
                Assert.Null(this.custService.GetRecordByName("TEST"));
            }
            else
            {
                Assert.NotNull(cust);
            }
        }
    }
}